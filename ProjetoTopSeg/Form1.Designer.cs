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
            button2 = new Button();
            btnEnviar = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(682, 420);
            button2.Name = "button2";
            button2.Size = new Size(101, 54);
            button2.TabIndex = 15;
            button2.Text = "Desconectar-se";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(597, 420);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(77, 54);
            btnEnviar.TabIndex = 14;
            btnEnviar.Text = "Enviar Mensagem";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 402);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 13;
            label3.Text = "Seu texto aqui:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 420);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(566, 54);
            textBox1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(620, 36);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 11;
            label2.Text = "Lista de Usuários:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 10;
            label1.Text = "Chat:";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(620, 54);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(163, 334);
            listBox2.TabIndex = 9;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 54);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(566, 334);
            listBox1.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 494);
            Controls.Add(button2);
            Controls.Add(btnEnviar);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button btnEnviar;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private ListBox listBox2;
        private ListBox listBox1;
    }
}
