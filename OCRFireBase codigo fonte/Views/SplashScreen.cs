using Google.Cloud.Firestore;
using OCRFireBase.Models;

namespace OCRFireBase.Views
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            try
            {
                Validacao.ValidaPasta("temp");
                Validacao.ValidaPasta("thumbnail");
            }

            catch (Exception ex) { MessageBox.Show(ex.Message, "Nao foi possivel criar as pasta temp"); }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            await Task.Run(() => Login(textBox1.Text.Trim().ToLower(), textBox2.Text.Trim()));
            button1.Enabled = true;
        }

        private Task Login(string usuarioDigitado, string senhaDigitada)
        {
            // Initialize Firebase
            try
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredenciaisFireBase.arquivoCredencialJson);
                CollectionReference colRef = CredenciaisFireBase.GetCollectionRef();
                DocumentSnapshot doc = colRef.Document(CredenciaisFireBase.colecao).GetSnapshotAsync().Result;

                if (doc.Exists)
                {
                    Dictionary<string, object> data = doc.ToDictionary();

                    if (data.TryGetValue("usuario", out object usuarioValue) && data.TryGetValue("senha", out object senhaValue))
                    {
                        string? usuario = usuarioValue?.ToString();
                        string? senha = senhaValue?.ToString();

                        if (usuarioDigitado == usuario && senhaDigitada == senha)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.Hide();
                                FormPrincipal principal = new FormPrincipal();
                                principal.Show();
                            });

                            return Task.CompletedTask;
                        }

                        this.Invoke((MethodInvoker)delegate { label1.Visible = true; });
                    }
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }

            return Task.CompletedTask;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
