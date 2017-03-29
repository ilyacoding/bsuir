namespace RSA
{
    partial class FormHackKey
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
            this.labele = new System.Windows.Forms.Label();
            this.textBoxe = new System.Windows.Forms.TextBox();
            this.textBoxr = new System.Windows.Forms.TextBox();
            this.labelr = new System.Windows.Forms.Label();
            this.labeld = new System.Windows.Forms.Label();
            this.textBoxd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labele
            // 
            this.labele.AutoSize = true;
            this.labele.Location = new System.Drawing.Point(4, 65);
            this.labele.Name = "labele";
            this.labele.Size = new System.Drawing.Size(16, 17);
            this.labele.TabIndex = 17;
            this.labele.Text = "e";
            // 
            // textBoxe
            // 
            this.textBoxe.Location = new System.Drawing.Point(26, 62);
            this.textBoxe.Name = "textBoxe";
            this.textBoxe.Size = new System.Drawing.Size(438, 22);
            this.textBoxe.TabIndex = 16;
            this.textBoxe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxe_KeyPress);
            // 
            // textBoxr
            // 
            this.textBoxr.Location = new System.Drawing.Point(26, 34);
            this.textBoxr.Name = "textBoxr";
            this.textBoxr.Size = new System.Drawing.Size(438, 22);
            this.textBoxr.TabIndex = 15;
            this.textBoxr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxr_KeyPress);
            // 
            // labelr
            // 
            this.labelr.AutoSize = true;
            this.labelr.Location = new System.Drawing.Point(7, 39);
            this.labelr.Name = "labelr";
            this.labelr.Size = new System.Drawing.Size(13, 17);
            this.labelr.TabIndex = 14;
            this.labelr.Text = "r";
            // 
            // labeld
            // 
            this.labeld.AutoSize = true;
            this.labeld.Location = new System.Drawing.Point(4, 90);
            this.labeld.Name = "labeld";
            this.labeld.Size = new System.Drawing.Size(16, 17);
            this.labeld.TabIndex = 13;
            this.labeld.Text = "d";
            // 
            // textBoxd
            // 
            this.textBoxd.Location = new System.Drawing.Point(26, 90);
            this.textBoxd.Name = "textBoxd";
            this.textBoxd.ReadOnly = true;
            this.textBoxd.Size = new System.Drawing.Size(438, 22);
            this.textBoxd.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Get Private Key";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormHackKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 169);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labele);
            this.Controls.Add(this.textBoxe);
            this.Controls.Add(this.textBoxr);
            this.Controls.Add(this.labelr);
            this.Controls.Add(this.labeld);
            this.Controls.Add(this.textBoxd);
            this.Name = "FormHackKey";
            this.Text = "Hack RSA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labele;
        private System.Windows.Forms.TextBox textBoxe;
        private System.Windows.Forms.TextBox textBoxr;
        private System.Windows.Forms.Label labelr;
        private System.Windows.Forms.Label labeld;
        private System.Windows.Forms.TextBox textBoxd;
        private System.Windows.Forms.Button button1;
    }
}