﻿namespace OCRFireBase.Views
{
    public partial class FormSalvarComo : Form
    {
        public FormSalvarComo()
        {
            InitializeComponent();
        }

        public int escolha;

        //btn diretorio
        private void button1_Click(object sender, EventArgs e)
        {
            escolha = 1;
            this.Close();
        }

        //btn nuvem
        private void button2_Click(object sender, EventArgs e)
        {
            escolha = 2;
            this.Close();
        }
    }
}
