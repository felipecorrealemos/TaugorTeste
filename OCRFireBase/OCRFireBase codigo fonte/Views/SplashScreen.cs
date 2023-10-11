using Google.Cloud.Firestore;
using OCRFireBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Login();
        }

        private void Login()
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
                        string usuario = usuarioValue.ToString();
                        string senha = senhaValue.ToString();

                        string usuarioDigitado = Validacao.ValidaCamposDigitados(textBox1.Text.Trim());
                        string senhaDigitada = Validacao.ValidaCamposDigitados(textBox2.Text.Trim());

                        if (usuarioDigitado == usuario && senhaDigitada == senha)
                        {
                            this.Hide();

                            FormPrincipal principal = new FormPrincipal();
                            principal.Show();
                            return;
                        }

                        label1.Visible = true;
                    }
                }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
