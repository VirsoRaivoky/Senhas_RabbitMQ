namespace SenhaS
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
            this.radioButtonPadrao = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.senha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.nameList = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonPadrao
            // 
            this.radioButtonPadrao.AutoSize = true;
            this.radioButtonPadrao.Location = new System.Drawing.Point(292, 308);
            this.radioButtonPadrao.Name = "radioButtonPadrao";
            this.radioButtonPadrao.Size = new System.Drawing.Size(76, 24);
            this.radioButtonPadrao.TabIndex = 0;
            this.radioButtonPadrao.TabStop = true;
            this.radioButtonPadrao.Text = "Padrão";
            this.radioButtonPadrao.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(421, 308);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Preferencial";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Senha Atual";
            // 
            // senha
            // 
            this.senha.AutoSize = true;
            this.senha.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.senha.Location = new System.Drawing.Point(101, 103);
            this.senha.Name = "senha";
            this.senha.Size = new System.Drawing.Size(56, 67);
            this.senha.TabIndex = 3;
            this.senha.Text = "0";
            this.senha.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.senha);
            this.panel1.Location = new System.Drawing.Point(279, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 194);
            this.panel1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "Pegar Senha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameList
            // 
            this.nameList.Location = new System.Drawing.Point(21, 49);
            this.nameList.Name = "nameList";
            this.nameList.Size = new System.Drawing.Size(214, 362);
            this.nameList.TabIndex = 6;
            this.nameList.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 35);
            this.label2.TabIndex = 7;
            this.label2.Text = "Lista de chamada";
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(267, 265);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(274, 27);
            this.nameField.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(363, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nome";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameList);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButtonPadrao);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton radioButtonPadrao;
        private RadioButton radioButton2;
        private Label label1;
        private Label senha;
        private Panel panel1;
        private Button button1;
        private RichTextBox nameList;
        private Label label2;
        private TextBox nameField;
        private Label label3;
    }
}