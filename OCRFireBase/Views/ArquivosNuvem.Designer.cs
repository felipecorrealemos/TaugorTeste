namespace OCRFireBase.Views
{
    partial class ArquivosNuvem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArquivosNuvem));
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            progressBar1 = new ProgressBar();
            labelAguardar = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(24, 77);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(320, 298);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(24, 48);
            label1.Name = "label1";
            label1.Size = new Size(138, 28);
            label1.TabIndex = 1;
            label1.Text = "Arquivos salvos:";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(359, 77);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(210, 297);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(244, 48);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 9;
            progressBar1.Value = 1;
            // 
            // labelAguardar
            // 
            labelAguardar.AutoSize = true;
            labelAguardar.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelAguardar.Location = new Point(231, 26);
            labelAguardar.Name = "labelAguardar";
            labelAguardar.Size = new Size(133, 21);
            labelAguardar.TabIndex = 10;
            labelAguardar.Text = "Carregando aguarde";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.icone_google_cloud;
            pictureBox1.Location = new Point(507, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(62, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // ArquivosNuvem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(593, 404);
            Controls.Add(pictureBox1);
            Controls.Add(labelAguardar);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "ArquivosNuvem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Google Cloud - Fire Store";
            Load += ArquivosNuvem_LoadAsync;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private PictureBox pictureBox2;
        private ProgressBar progressBar1;
        private Label labelAguardar;
        private PictureBox pictureBox1;
    }
}