namespace OCRFireBase.Views
{
    partial class FormSalvarComo
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(43, 76);
            button1.Name = "button1";
            button1.Size = new Size(86, 46);
            button1.TabIndex = 0;
            button1.Text = "Diretório";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe Print", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(157, 76);
            button2.Name = "button2";
            button2.Size = new Size(86, 46);
            button2.TabIndex = 1;
            button2.Text = "Nuvem";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(53, 28);
            label1.Name = "label1";
            label1.Size = new Size(176, 28);
            label1.TabIndex = 2;
            label1.Text = "Onde deseja salvar ?";
            // 
            // FormSalvarComo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(284, 159);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSalvarComo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Salvar como";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
    }
}