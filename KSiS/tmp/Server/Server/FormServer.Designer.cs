namespace Server
{
    partial class FormServer
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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.richTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(154, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(12, 9);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(136, 17);
            this.labelIP.TabIndex = 4;
            this.labelIP.Text = "IP: 255.255.255.255";
            // 
            // richTextBoxConsole
            // 
            this.richTextBoxConsole.Location = new System.Drawing.Point(15, 35);
            this.richTextBoxConsole.Name = "richTextBoxConsole";
            this.richTextBoxConsole.Size = new System.Drawing.Size(598, 96);
            this.richTextBoxConsole.TabIndex = 5;
            this.richTextBoxConsole.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 350);
            this.Controls.Add(this.richTextBoxConsole);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.buttonStart);
            this.Name = "FormServer";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.RichTextBox richTextBoxConsole;
        private System.Windows.Forms.Timer timer1;
    }
}

