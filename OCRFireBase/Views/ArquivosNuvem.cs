using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using OCRFireBase.Models;
using Org.BouncyCastle.Asn1.Cmp;
using SautinSoft.Document;
using System.Drawing.Imaging;
using System.Globalization;

namespace OCRFireBase.Views
{
    public partial class ArquivosNuvem : Form
    {
        public ArquivosNuvem()
        {
            InitializeComponent();
        }

        List<PictureBox> listaPictureBox = new List<PictureBox>();

        private async void ArquivosNuvem_LoadAsync(object sender, EventArgs e)
        {
            ApagarThumbsExistentes();

            await Task.Run(() => DownloadThumbs());
            labelAguardar.Visible = false;
            progressBar1.Visible = false;
        }

        private void ApagarThumbsExistentes()
        {
            try
            {
                string diretoriothumb = Path.Combine(Directory.GetCurrentDirectory(), "thumbnail");
                string[] arquivos = Directory.GetFiles(diretoriothumb);

                foreach (var arquivo in arquivos)
                {
                    if (File.Exists(arquivo))
                    {
                        File.Delete(arquivo);
                    }
                }
            }

            catch { }
        }

        private async void DownloadThumbs()
        {
            var storage = CredenciaisFireBase.GetStorageClient();
            var objects = storage.ListObjects(CredenciaisFireBase.bucket);

            this.Invoke((MethodInvoker)delegate
            {
                progressBar1.Maximum = objects.Count() + 1;
            });

            string diretoriothumb = Path.Combine(Directory.GetCurrentDirectory(), "thumbnail");

            int a = 0;
            //download dos pdf na pasta thumbnail
            foreach (var storageObject in objects)
            {
                if (Path.GetExtension(storageObject.Name) == ".pdf")
                {
                    string novoArquivo = Path.Combine(diretoriothumb, $"{storageObject.Name}");
                    using (var outputFile = File.OpenWrite(novoArquivo))
                    {
                        storage.DownloadObject(CredenciaisFireBase.bucket, storageObject.Name, outputFile);
                    }
                }
                a++;
            }

            string[] thumbs = Directory.GetFiles(diretoriothumb);
            int pos = 0;
            //transforma os pdf da pasta thumb em imagem no pictureBox
            foreach (var thumb in thumbs)
            {
                DocumentCore dc = DocumentCore.Load(thumb);

                // PaginationOptions allow to know, how many pages we have in the document.
                DocumentPaginator dp = dc.GetPaginator(new PaginatorOptions());

                // Each document page will be saved in its own image format: PNG, JPEG, TIFF with different DPI.
                using (Stream stream = new MemoryStream())
                {
                    dp.Pages[0].Rasterize(800, SautinSoft.Document.Color.White).Save(stream, ImageFormat.Png);
                    Bitmap imagem = new Bitmap(stream);

                    PictureBox pictureBox = CriaPictureBox(imagem, pos);
                    listaPictureBox.Add(pictureBox);

                    Label labelNomeArquivo = new Label();
                    labelNomeArquivo.Text = new FileInfo(thumb).Name;
                    labelNomeArquivo.Font = new Font(labelNomeArquivo.Font.FontFamily, 7);
                    labelNomeArquivo.Location = new Point(3, 3);
                    pictureBox.Controls.Add(labelNomeArquivo);

                    Label labeltamanhoArquivo = new Label();
                    double megabytes = (double)new FileInfo(thumb).Length / (1024 * 1024);
                    labeltamanhoArquivo.Text = megabytes.ToString("F2", CultureInfo.InvariantCulture) + " MB";
                    labeltamanhoArquivo.Location = new Point(50, 50);
                    pictureBox.Controls.Add(labeltamanhoArquivo);

                    this.Invoke((MethodInvoker)delegate
                    {
                        flowLayoutPanel1.Controls.Add(pictureBox);
                        progressBar1.Value += 1;
                    });
                }
                pos++;
            }
        }

        private PictureBox CriaPictureBox(Image imagem, int pos)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = imagem;
            pictureBox.Size = new Size(100, 70);
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Name = $"pictureBox{pos}";
            pictureBox.Click += PictureBox_Click;
            pictureBox.BackColor = System.Drawing.Color.White;

            return pictureBox;
        }

        private async void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            DesativaBordas();
            pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //MessageBox.Show($"{pictureBox.Name} clicada!");
            await Task.Run(() => pictureBox2.Image = pictureBox.Image);
        }

        private void DesativaBordas()
        {
            foreach (var pictureBox in listaPictureBox)
            {
                pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            }
        }
    }
}
