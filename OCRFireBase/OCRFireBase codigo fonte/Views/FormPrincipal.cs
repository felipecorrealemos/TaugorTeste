using OCRFireBase.Views;

namespace OCRFireBase
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        //btn digitalizar
        private void button2_Click(object sender, EventArgs e)
        {
            DigitalizarDoc Form = new DigitalizarDoc();
            Form.ShowDialog();
        }

        //btn arquivos nuvem
        private void button1_Click(object sender, EventArgs e)
        {
            ArquivosNuvem form = new ArquivosNuvem();
            form.ShowDialog();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}