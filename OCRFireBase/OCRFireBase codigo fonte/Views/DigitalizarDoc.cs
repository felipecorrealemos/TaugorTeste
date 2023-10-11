using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OCRFireBase.Models;
using SautinSoft.Document;
using System.Diagnostics;
using System.Drawing.Imaging;
using WIA;

namespace OCRFireBase.Views
{
    public partial class DigitalizarDoc : Form
    {
        public DigitalizarDoc()
        {
            InitializeComponent();
        }

        private int iniWidthPictureBox;
        private int iniHeightPictureBox;
        string arquivoSelecionado;
        private int rotationAngle = 0;
        private Bitmap originalImage;
        private Bitmap rotatedImage;
        private Bitmap originalImageOCR;
        private Bitmap rotatedImageOCR;

        private void DigitalizarDoc_Load(object sender, EventArgs e)
        {
            //carregando idioma
            comboBox2.Items.Add("Ingles (Padrão)");
            comboBox2.Items.Add("Português Brasil");
            comboBox2.SelectedIndex = 0;

            iniHeightPictureBox = pictureBox1.Height;
            iniWidthPictureBox = pictureBox1.Width;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                IDeviceManager manager = new DeviceManager();
                foreach (IDeviceInfo deviceInfo in manager.DeviceInfos)
                {
                    if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                    {
                        comboBox1.Items.Add(deviceInfo.Properties["Name"].get_Value().ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar o scanner");
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        //btn digitalizar pdf
        private void button1_Click(object sender, EventArgs e)
        {
            EscaneandoDocs();
        }

        private async void EscaneandoDocs()
        {
            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("Nenhum escaner disponivel");
                return;
            }

            string appDataPathTemp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OCRFireBase");
            appDataPathTemp = Path.Combine(appDataPathTemp, "temp");

            string txtLog = Path.Combine(appDataPathTemp, "log.txt");
            Log.CriarArquivoLog(txtLog, "Criando arquivo log.");


            try
            {
                //escaneando documento
                LimpandoBitmaps();

                string pdfPath = Path.Combine(appDataPathTemp, "file.pdf"); ;
                string pdfOutput = Path.Combine(appDataPathTemp, "output.pdf");


                IDeviceManager manager = new DeviceManager();
                foreach (IDeviceInfo deviceInfo in manager.DeviceInfos)
                {
                    if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                    {
                        // Comparar o nome do scanner com o nome desejado (ignorando maiúsculas/minúsculas)
                        if (String.Compare(deviceInfo.Properties["Name"].get_Value().ToString(), comboBox1.Text, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            IDevice dev = deviceInfo.Connect();
                            foreach (IItem item in dev.Items)
                            {
                                // Cria documento PDF
                                string tempFilePath = Path.Combine(appDataPathTemp, "file123.jpeg");

                                //Envia comando para o escaner WIA ler o documento no vidro
                                IImageFile file0 = await Task.Run(() => (IImageFile)item.Transfer("{00000000-0000-0000-0000-000000000000}"));
                                using (MemoryStream stream = new MemoryStream((byte[])file0.FileData.get_BinaryData()))
                                {
                                    originalImage = (Bitmap)System.Drawing.Image.FromStream(stream);
                                }

                                file0.SaveFile(tempFilePath);
                                pictureBox1.Image = new Bitmap(originalImage);

                                using (var doc = new iTextSharp.text.Document())
                                {
                                    iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                                    doc.Open();

                                    iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(tempFilePath);
                                    pdfImage.ScaleAbsoluteHeight(doc.PageSize.Height - 60);
                                    pdfImage.ScaleAbsoluteWidth(doc.PageSize.Width - 60);
                                    doc.Add(pdfImage);

                                    File.Delete(tempFilePath);
                                }

                                //Cria arquivo TIFF
                                //IImageFile file = (IImageFile)item.Transfer("{00000000-0000-0000-0000-000000000000}");
                                //file.SaveFile("C:\\file.tiff");

                                //Cria arquivo JPEG
                                //IImageFile file2 = (IImageFile)item.Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
                                // file2.SaveFile("C:\\file.jpeg");
                            }
                            break;
                        }
                    }
                }

                button4.Enabled = true;
                button6.Enabled = true;

                //OCR Habilitado
                if (checkBox2.Checked)
                {
                    Log.AdicionarLog(txtLog, "entrou no checkbox2.checked");
                    string idioma = VerificaIdioma();

                    //var task = Task.Run(() => OCR.ScanDocOCRAsync(idioma));
                    var task = OCR.ScanDocOCRAsync(idioma);
                    await task;
                    Log.AdicionarLog(txtLog, "concluiu a task OCR.ScanDocOCRAsync");

                    /*while (!Validacao.VerificaSeArquivoDisponivel(pdfOutput))
                    {
                        await Task.Delay(100);
                    }*/

                    //Log.AdicionarLog(txtLog, "concluiu verificacao de arquivo disponivel pdfOutput");

                    DocumentCore dc = DocumentCore.Load(pdfOutput);

                    // PaginationOptions allow to know, how many pages we have in the document.
                    DocumentPaginator dp = dc.GetPaginator(new PaginatorOptions());

                    // Each document page will be saved in its own image format: PNG, JPEG, TIFF with different DPI.
                    using (Stream stream = new MemoryStream())
                    {
                        dp.Pages[0].Rasterize(800, SautinSoft.Document.Color.White).Save(stream, ImageFormat.Jpeg);
                        Bitmap imagem = new Bitmap(stream);
                        pictureBox2.Image = imagem;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        originalImageOCR = imagem;
                    }

                    button10.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a digitalização: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(txtLog))
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        //btn abrir
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";  // Defina o diretório inicial se desejar
                openFileDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf|Todos os Arquivos (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // O usuário escolheu um arquivo
                    arquivoSelecionado = openFileDialog.FileName;

                    originalImage = new Bitmap(arquivoSelecionado);
                    pictureBox1.Image = originalImage;
                }
            }
        }

        //btn cancelar
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //btn girar 90 graus
        private void button4_Click(object sender, EventArgs e)
        {
            rotationAngle += 90;
            rotationAngle %= 360;

            rotatedImage = RotateBitmap(originalImage, rotationAngle);
            pictureBox1.Image = rotatedImage;
        }

        private Bitmap RotateBitmap(Bitmap source, float angle)
        {
            double radians = angle * Math.PI / 180;

            double sin = Math.Abs(Math.Sin(radians));
            double cos = Math.Abs(Math.Cos(radians));

            int newWidth = (int)Math.Round(source.Width * cos + source.Height * sin);
            int newHeight = (int)Math.Round(source.Width * sin + source.Height * cos);

            Bitmap rotatedBitmap = new Bitmap(newWidth, newHeight);
            rotatedBitmap.SetResolution(source.HorizontalResolution, source.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                g.TranslateTransform(newWidth / 2, newHeight / 2);
                g.RotateTransform(angle);
                g.TranslateTransform(-source.Width / 2, -source.Height / 2);

                g.DrawImage(source, new System.Drawing.Point(0, 0));
            }

            //inverte o picktureBox
            if (pictureBox1.Height == iniHeightPictureBox)
            {
                pictureBox1.Height = 250;
                pictureBox1.Width = 332;
                //    pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }

            else
            {
                pictureBox1.Height = iniHeightPictureBox;
                pictureBox1.Width = iniWidthPictureBox;

            }

            return rotatedBitmap;
        }

        //btn salvar pdf
        private async void button6_Click(object sender, EventArgs e)
        {
            try
            {
                await SalvaPDF("Scan", originalImage, rotatedImage, checkBox1, @"file.pdf");
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                button4.Enabled = false;
                button6.Enabled = false;
                pictureBox1.Image = null;
            }
        }

        private static void ConvertePDFparaPDFA(string inpFile, string outFile)
        {
            // Specifying PdfLoadOptions we explicitly set that a loadable document is PDF.
            PdfLoadOptions pdfLO = new PdfLoadOptions()
            {
                // 'false' - means to load vector graphics as is. Don't transform it to raster images.
                RasterizeVectorGraphics = false,

                // The PDF format doesn't have real tables, in fact it's a set of orthogonal graphic lines.
                // In case of 'true' the component will detect and recreate tables from graphic lines.
                DetectTables = false,
                // 'Disabled' - Never load embedded fonts in PDF. Use the fonts with the same name installed at the system or similar by font metrics.
                // 'Enabled' - Always load embedded fonts in PDF.
                // 'Auto' - Load only embedded fonts missing in the system. In other case, use the system fonts.				
                PreserveEmbeddedFonts = PropertyState.Auto
            };

            DocumentCore dc = DocumentCore.Load(inpFile, pdfLO);

            PdfSaveOptions pdfSO = new PdfSaveOptions()
            {
                Compliance = PdfCompliance.PDF_A1a
            };

            dc.Save(outFile, pdfSO);
            File.Delete(inpFile);

            // Open the result for demonstration purposes.
            //System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outFile) { UseShellExecute = true });
        }

        //atualiza scanner
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                IDeviceManager manager = new DeviceManager();
                foreach (IDeviceInfo deviceInfo in manager.DeviceInfos)
                {
                    if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                    {
                        comboBox1.Items.Add(deviceInfo.Properties["Name"].get_Value().ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                // MessageBox.Show("Erro ao verificar o scanner");
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        //btn salvar pdf com OCR
        private async void button10_Click(object sender, EventArgs e)
        {
            try
            {
                await SalvaPDF("ScanOCR", originalImageOCR, rotatedImageOCR, checkBox1, @"output.pdf");
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            finally
            {
                button10.Enabled = false;
                pictureBox2.Image = null;
            }
        }

        private async static Task SalvaPDF(string nomeArq, Bitmap originalImage, Bitmap rotatedImage, CheckBox checkBox, string arqTemp)
        {
            string nomeArquivo = $"{nomeArq} {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")}.pdf";
            nomeArquivo = string.Join("_", nomeArquivo.Split(Path.GetInvalidFileNameChars()));

            FormSalvarComo form = new FormSalvarComo();
            form.ShowDialog();

            try
            {
                if (form.escolha == 1)
                {
                    //escolheu salvar no diretorio
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF|*.pdf";

                        saveFileDialog.FileName = nomeArquivo;
                        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            Bitmap bitmapASalvar;
                            if (rotatedImage != null)
                            {
                                bitmapASalvar = new Bitmap(rotatedImage);
                                rotatedImage.Dispose();
                            }

                            else
                            {
                                bitmapASalvar = new Bitmap(originalImage);
                                originalImage.Dispose();
                            }

                            string novoPdf = saveFileDialog.FileName;

                            iTextSharp.text.Rectangle rectangle = null;

                            if (rotatedImage != null)
                            {
                                rectangle = new iTextSharp.text.Rectangle(PageSize.A4.Rotate());
                            }

                            else
                            {
                                rectangle = new iTextSharp.text.Rectangle(PageSize.A4);
                            }

                            using (var doc = new iTextSharp.text.Document(rectangle))
                            {
                                PdfWriter.GetInstance(doc, new FileStream(novoPdf, FileMode.Create));
                                doc.Open();

                                iTextSharp.text.Image pdfImage;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    bitmapASalvar.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                                    pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                                }

                                pdfImage.ScaleAbsoluteHeight(doc.PageSize.Height - 60);
                                pdfImage.ScaleAbsoluteWidth(doc.PageSize.Width - 60);

                                // pdfImage.ScalePercent(35);

                                doc.Add(pdfImage);
                            }

                            //Criar PDFA e exclui o pdf normal
                            if (checkBox.Checked)
                            {
                                string output = novoPdf.Insert(novoPdf.Length - 4, "_PDFA");
                                ConvertePDFparaPDFA(novoPdf, output);
                            }

                            MessageBox.Show("PDF salvo com sucesso!");
                        }
                    }
                }

                else
                {
                    //escolheu salvar na nuvem
                    var storage = CredenciaisFireBase.GetStorageClient();

                    string appDataPathTemp = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OCRFireBase");
                    appDataPathTemp = Path.Combine(appDataPathTemp, "temp");

                    FileInfo fileInfo = new FileInfo(Path.Combine(appDataPathTemp, arqTemp));
                    //byte[] bytes = await Task.Run(() => Encoding.UTF8.GetBytes(fileInfo.FullName));

                    await using (var fileStream = File.OpenRead(fileInfo.FullName))
                    {
                        fileStream.Seek(0, SeekOrigin.Begin);
                        var uploadObjectOptions = new UploadObjectOptions { };

                        await storage.UploadObjectAsync(CredenciaisFireBase.bucket, nomeArquivo, "application/pdf", fileStream, uploadObjectOptions);
                    }

                    MessageBox.Show("Upload de imagem concluida!");
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpandoBitmaps()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            originalImage = null;
            rotatedImage = null;
            originalImageOCR = null;
            rotatedImageOCR = null;
        }

        private string VerificaIdioma()
        {

            if (comboBox2.Text == "Português Brasil")
            {
                return "por";
            }

            else
            {
                return "eng";
            }
        }
    }
}