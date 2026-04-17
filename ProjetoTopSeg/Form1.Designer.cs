namespace ProjetoTopSeg
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelUser = new Label();
            labelPass = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnEntrar = new Button();
            SuspendLayout();
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Location = new Point(29, 17);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(60, 15);
            labelUser.TabIndex = 0;
            labelUser.Text = "Username";
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Location = new Point(29, 89);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(57, 15);
            labelPass.TabIndex = 1;
            labelPass.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 23);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(29, 107);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(240, 23);
            textBox2.TabIndex = 3;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(29, 145);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(71, 36);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 193);
            Controls.Add(btnEntrar);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(labelPass);
            Controls.Add(labelUser);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUser;
        private Label labelPass;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnEntrar;
    }
}
