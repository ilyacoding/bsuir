namespace RSA
{
    partial class FormRSA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRSA));
            this.textBoxp = new System.Windows.Forms.TextBox();
            this.textBoxq = new System.Windows.Forms.TextBox();
            this.labelp = new System.Windows.Forms.Label();
            this.labelq = new System.Windows.Forms.Label();
            this.textBoxd = new System.Windows.Forms.TextBox();
            this.labeld = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.labelr = new System.Windows.Forms.Label();
            this.textBoxr = new System.Windows.Forms.TextBox();
            this.textBoxe = new System.Windows.Forms.TextBox();
            this.labele = new System.Windows.Forms.Label();
            this.buttonGenKey = new System.Windows.Forms.Button();
            this.buttonHackKey = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGenPrime = new System.Windows.Forms.Button();
            this.buttonMerc = new System.Windows.Forms.Button();
            this.textBoxPrime = new System.Windows.Forms.TextBox();
            this.textBoxKo = new System.Windows.Forms.TextBox();
            this.textBoxKc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelrK = new System.Windows.Forms.Label();
            this.labeleK = new System.Windows.Forms.Label();
            this.textBoxFd = new System.Windows.Forms.TextBox();
            this.textBoxFr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labeldE = new System.Windows.Forms.Label();
            this.buttonGenSmallPrime = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxp
            // 
            this.textBoxp.Location = new System.Drawing.Point(28, 94);
            this.textBoxp.Name = "textBoxp";
            this.textBoxp.Size = new System.Drawing.Size(838, 22);
            this.textBoxp.TabIndex = 0;
            this.textBoxp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxp_KeyPress);
            // 
            // textBoxq
            // 
            this.textBoxq.Location = new System.Drawing.Point(28, 122);
            this.textBoxq.Name = "textBoxq";
            this.textBoxq.Size = new System.Drawing.Size(838, 22);
            this.textBoxq.TabIndex = 1;
            this.textBoxq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxq_KeyPress);
            // 
            // labelp
            // 
            this.labelp.AutoSize = true;
            this.labelp.Location = new System.Drawing.Point(6, 94);
            this.labelp.Name = "labelp";
            this.labelp.Size = new System.Drawing.Size(16, 17);
            this.labelp.TabIndex = 2;
            this.labelp.Text = "p";
            // 
            // labelq
            // 
            this.labelq.AutoSize = true;
            this.labelq.Location = new System.Drawing.Point(6, 125);
            this.labelq.Name = "labelq";
            this.labelq.Size = new System.Drawing.Size(16, 17);
            this.labelq.TabIndex = 3;
            this.labelq.Text = "q";
            // 
            // textBoxd
            // 
            this.textBoxd.Location = new System.Drawing.Point(28, 152);
            this.textBoxd.Name = "textBoxd";
            this.textBoxd.Size = new System.Drawing.Size(766, 22);
            this.textBoxd.TabIndex = 4;
            this.textBoxd.TextChanged += new System.EventHandler(this.textBoxd_TextChanged);
            this.textBoxd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxd_KeyPress);
            // 
            // labeld
            // 
            this.labeld.AutoSize = true;
            this.labeld.Location = new System.Drawing.Point(6, 155);
            this.labeld.Name = "labeld";
            this.labeld.Size = new System.Drawing.Size(16, 17);
            this.labeld.TabIndex = 5;
            this.labeld.Text = "d";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "D:\\BSUIR\\Теория информации\\лаба 4_RSA\\files";
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSelectFile.Location = new System.Drawing.Point(28, 434);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(78, 32);
            this.buttonSelectFile.TabIndex = 6;
            this.buttonSelectFile.Text = "Select file";
            this.buttonSelectFile.UseVisualStyleBackColor = false;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Enabled = false;
            this.buttonEncrypt.Location = new System.Drawing.Point(115, 434);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(161, 32);
            this.buttonEncrypt.TabIndex = 7;
            this.buttonEncrypt.Text = "Encrypt (using public)";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // labelr
            // 
            this.labelr.AutoSize = true;
            this.labelr.Location = new System.Drawing.Point(6, 183);
            this.labelr.Name = "labelr";
            this.labelr.Size = new System.Drawing.Size(13, 17);
            this.labelr.TabIndex = 8;
            this.labelr.Text = "r";
            // 
            // textBoxr
            // 
            this.textBoxr.Location = new System.Drawing.Point(28, 180);
            this.textBoxr.Name = "textBoxr";
            this.textBoxr.ReadOnly = true;
            this.textBoxr.Size = new System.Drawing.Size(766, 22);
            this.textBoxr.TabIndex = 9;
            this.textBoxr.TextChanged += new System.EventHandler(this.textBoxr_TextChanged);
            // 
            // textBoxe
            // 
            this.textBoxe.Location = new System.Drawing.Point(28, 208);
            this.textBoxe.Name = "textBoxe";
            this.textBoxe.ReadOnly = true;
            this.textBoxe.Size = new System.Drawing.Size(766, 22);
            this.textBoxe.TabIndex = 10;
            this.textBoxe.TextChanged += new System.EventHandler(this.textBoxe_TextChanged);
            // 
            // labele
            // 
            this.labele.AutoSize = true;
            this.labele.Location = new System.Drawing.Point(6, 211);
            this.labele.Name = "labele";
            this.labele.Size = new System.Drawing.Size(16, 17);
            this.labele.TabIndex = 11;
            this.labele.Text = "e";
            // 
            // buttonGenKey
            // 
            this.buttonGenKey.Location = new System.Drawing.Point(28, 48);
            this.buttonGenKey.Name = "buttonGenKey";
            this.buttonGenKey.Size = new System.Drawing.Size(151, 31);
            this.buttonGenKey.TabIndex = 12;
            this.buttonGenKey.Text = "Generate Public Key";
            this.buttonGenKey.UseVisualStyleBackColor = true;
            this.buttonGenKey.Click += new System.EventHandler(this.buttonGenKey_Click);
            // 
            // buttonHackKey
            // 
            this.buttonHackKey.Location = new System.Drawing.Point(185, 47);
            this.buttonHackKey.Name = "buttonHackKey";
            this.buttonHackKey.Size = new System.Drawing.Size(132, 32);
            this.buttonHackKey.TabIndex = 15;
            this.buttonHackKey.Text = "Hack Private Key";
            this.buttonHackKey.UseVisualStyleBackColor = true;
            this.buttonHackKey.Click += new System.EventHandler(this.buttonHackKey_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Enabled = false;
            this.buttonDecrypt.Location = new System.Drawing.Point(115, 472);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(161, 32);
            this.buttonDecrypt.TabIndex = 16;
            this.buttonDecrypt.Text = "Decrypt (using private)";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(25, 559);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 17);
            this.labelFileName.TabIndex = 17;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(346, 454);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(257, 103);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(609, 454);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(257, 103);
            this.richTextBox2.TabIndex = 19;
            this.richTextBox2.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Output:";
            // 
            // buttonGenPrime
            // 
            this.buttonGenPrime.Location = new System.Drawing.Point(323, 44);
            this.buttonGenPrime.Name = "buttonGenPrime";
            this.buttonGenPrime.Size = new System.Drawing.Size(80, 23);
            this.buttonGenPrime.TabIndex = 22;
            this.buttonGenPrime.Text = "GenPrime";
            this.buttonGenPrime.UseVisualStyleBackColor = true;
            this.buttonGenPrime.Click += new System.EventHandler(this.buttonGenPrime_Click);
            // 
            // buttonMerc
            // 
            this.buttonMerc.Location = new System.Drawing.Point(323, 69);
            this.buttonMerc.Name = "buttonMerc";
            this.buttonMerc.Size = new System.Drawing.Size(80, 23);
            this.buttonMerc.TabIndex = 25;
            this.buttonMerc.Text = "GenMerc";
            this.buttonMerc.UseVisualStyleBackColor = true;
            this.buttonMerc.Click += new System.EventHandler(this.buttonMerc_Click);
            // 
            // textBoxPrime
            // 
            this.textBoxPrime.Location = new System.Drawing.Point(409, 44);
            this.textBoxPrime.Name = "textBoxPrime";
            this.textBoxPrime.ReadOnly = true;
            this.textBoxPrime.Size = new System.Drawing.Size(457, 22);
            this.textBoxPrime.TabIndex = 26;
            // 
            // textBoxKo
            // 
            this.textBoxKo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKo.Location = new System.Drawing.Point(28, 236);
            this.textBoxKo.Name = "textBoxKo";
            this.textBoxKo.Size = new System.Drawing.Size(838, 34);
            this.textBoxKo.TabIndex = 27;
            // 
            // textBoxKc
            // 
            this.textBoxKc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxKc.Location = new System.Drawing.Point(28, 276);
            this.textBoxKc.Name = "textBoxKc";
            this.textBoxKc.Size = new System.Drawing.Size(838, 34);
            this.textBoxKc.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-41, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(2108, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 30;
            this.label4.Text = "Key generation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 25);
            this.label5.TabIndex = 31;
            this.label5.Text = "File encryption/decryption";
            // 
            // labelrK
            // 
            this.labelrK.AutoSize = true;
            this.labelrK.Location = new System.Drawing.Point(800, 183);
            this.labelrK.Name = "labelrK";
            this.labelrK.Size = new System.Drawing.Size(35, 17);
            this.labelrK.TabIndex = 32;
            this.labelrK.Text = "0 bit";
            // 
            // labeleK
            // 
            this.labeleK.AutoSize = true;
            this.labeleK.Location = new System.Drawing.Point(800, 211);
            this.labeleK.Name = "labeleK";
            this.labeleK.Size = new System.Drawing.Size(35, 17);
            this.labeleK.TabIndex = 33;
            this.labeleK.Text = "0 bit";
            // 
            // textBoxFd
            // 
            this.textBoxFd.Location = new System.Drawing.Point(346, 340);
            this.textBoxFd.Name = "textBoxFd";
            this.textBoxFd.Size = new System.Drawing.Size(520, 22);
            this.textBoxFd.TabIndex = 34;
            // 
            // textBoxFr
            // 
            this.textBoxFr.Location = new System.Drawing.Point(346, 396);
            this.textBoxFr.Name = "textBoxFr";
            this.textBoxFr.Size = new System.Drawing.Size(520, 22);
            this.textBoxFr.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "K(d)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 399);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "K(r)";
            // 
            // textBoxFe
            // 
            this.textBoxFe.Location = new System.Drawing.Point(346, 368);
            this.textBoxFe.Name = "textBoxFe";
            this.textBoxFe.Size = new System.Drawing.Size(520, 22);
            this.textBoxFe.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "K(e)";
            // 
            // labeldE
            // 
            this.labeldE.AutoSize = true;
            this.labeldE.Location = new System.Drawing.Point(800, 155);
            this.labeldE.Name = "labeldE";
            this.labeldE.Size = new System.Drawing.Size(35, 17);
            this.labeldE.TabIndex = 40;
            this.labeldE.Text = "0 bit";
            // 
            // buttonGenSmallPrime
            // 
            this.buttonGenSmallPrime.Location = new System.Drawing.Point(409, 69);
            this.buttonGenSmallPrime.Name = "buttonGenSmallPrime";
            this.buttonGenSmallPrime.Size = new System.Drawing.Size(80, 23);
            this.buttonGenSmallPrime.TabIndex = 41;
            this.buttonGenSmallPrime.Text = "GenSmall";
            this.buttonGenSmallPrime.UseVisualStyleBackColor = true;
            this.buttonGenSmallPrime.Click += new System.EventHandler(this.buttonGenSmallPrime_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(115, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 32);
            this.button1.TabIndex = 42;
            this.button1.Text = "Import key";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(174, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Text = "FullCheck";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormRSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 585);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGenSmallPrime);
            this.Controls.Add(this.labeldE);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxFe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxFr);
            this.Controls.Add(this.textBoxFd);
            this.Controls.Add(this.labeleK);
            this.Controls.Add(this.labelrK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textBoxKc);
            this.Controls.Add(this.textBoxKo);
            this.Controls.Add(this.textBoxPrime);
            this.Controls.Add(this.buttonMerc);
            this.Controls.Add(this.buttonGenPrime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonHackKey);
            this.Controls.Add(this.buttonGenKey);
            this.Controls.Add(this.labele);
            this.Controls.Add(this.textBoxe);
            this.Controls.Add(this.textBoxr);
            this.Controls.Add(this.labelr);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.labeld);
            this.Controls.Add(this.textBoxd);
            this.Controls.Add(this.labelq);
            this.Controls.Add(this.labelp);
            this.Controls.Add(this.textBoxq);
            this.Controls.Add(this.textBoxp);
            this.Name = "FormRSA";
            this.Text = "/";
            this.Load += new System.EventHandler(this.FormRSA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxp;
        private System.Windows.Forms.TextBox textBoxq;
        private System.Windows.Forms.Label labelp;
        private System.Windows.Forms.Label labelq;
        private System.Windows.Forms.TextBox textBoxd;
        private System.Windows.Forms.Label labeld;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Label labelr;
        private System.Windows.Forms.TextBox textBoxr;
        private System.Windows.Forms.TextBox textBoxe;
        private System.Windows.Forms.Label labele;
        private System.Windows.Forms.Button buttonGenKey;
        private System.Windows.Forms.Button buttonHackKey;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonGenPrime;
        private System.Windows.Forms.Button buttonMerc;
        private System.Windows.Forms.TextBox textBoxPrime;
        private System.Windows.Forms.TextBox textBoxKo;
        private System.Windows.Forms.TextBox textBoxKc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelrK;
        private System.Windows.Forms.Label labeleK;
        private System.Windows.Forms.TextBox textBoxFd;
        private System.Windows.Forms.TextBox textBoxFr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labeldE;
        private System.Windows.Forms.Button buttonGenSmallPrime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

