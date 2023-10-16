namespace OCRFireBase.Views
{
    partial class DigitalizarDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DigitalizarDoc));
            label1 = new Label();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            comboBox2 = new ComboBox();
            label3 = new Label();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            button4 = new Button();
            button6 = new Button();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            button9 = new Button();
            button10 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(224, 35);
            label1.TabIndex = 0;
            label1.Text = "Digitalizar para PDF";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(23, 92);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(208, 25);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "Salvar documento em PDF/A";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.Location = new Point(23, 135);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(249, 25);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "Reconhecer texto na imagem / OCR";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 173);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 3;
            label2.Text = "Idiomas OCR:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(23, 289);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(208, 23);
            comboBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(23, 317);
            button1.Name = "button1";
            button1.Size = new Size(141, 60);
            button1.TabIndex = 5;
            button1.Text = "Digitalizar para PDF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(224, 224, 224);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(23, 452);
            button2.Name = "button2";
            button2.Size = new Size(181, 31);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(23, 197);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(210, 23);
            comboBox2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(23, 265);
            label3.Name = "label3";
            label3.Size = new Size(156, 21);
            label3.TabIndex = 8;
            label3.Text = "Scanner disponivel WIA:";
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(170, 318);
            button3.Name = "button3";
            button3.Size = new Size(95, 59);
            button3.TabIndex = 9;
            button3.Text = "Abrir";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(401, 81);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 332);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(401, 423);
            button4.Name = "button4";
            button4.Size = new Size(75, 33);
            button4.TabIndex = 15;
            button4.Text = "Girar 90";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Enabled = false;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(561, 423);
            button6.Name = "button6";
            button6.Size = new Size(90, 33);
            button6.TabIndex = 20;
            button6.Text = "Salvar PDF";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(772, 81);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 332);
            pictureBox2.TabIndex = 21;
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDarkDark;
            panel1.Location = new Point(315, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(3, 453);
            panel1.TabIndex = 22;
            // 
            // button9
            // 
            button9.BackgroundImage = Properties.Resources.atualizar;
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button9.Location = new Point(239, 288);
            button9.Name = "button9";
            button9.Size = new Size(26, 23);
            button9.TabIndex = 25;
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Enabled = false;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button10.Location = new Point(772, 423);
            button10.Name = "button10";
            button10.Size = new Size(107, 33);
            button10.TabIndex = 26;
            button10.Text = "Salvar PDF";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // DigitalizarDoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1082, 515);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(pictureBox1);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "DigitalizarDoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digitalizar Documento";
            Load += DigitalizarDoc_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Label label2;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private ComboBox comboBox2;
        private Label label3;
        private Button button3;
        private PictureBox pictureBox1;
        private Button button4;
        private Button button6;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Button button9;
        private Button button10;
    }
}