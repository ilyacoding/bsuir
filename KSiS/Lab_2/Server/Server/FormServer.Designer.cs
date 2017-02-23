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
            this.labelOnline = new System.Windows.Forms.Label();
            this.timerClients = new System.Windows.Forms.Timer(this.components);
            this.labelConnected = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(159, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(12, 45);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(136, 17);
            this.labelIP.TabIndex = 4;
            this.labelIP.Text = "IP: 255.255.255.255";
            // 
            // labelOnline
            // 
            this.labelOnline.AutoSize = true;
            this.labelOnline.Location = new System.Drawing.Point(156, 45);
            this.labelOnline.Name = "labelOnline";
            this.labelOnline.Size = new System.Drawing.Size(99, 17);
            this.labelOnline.TabIndex = 6;
            this.labelOnline.Text = "Server: Offline";
            // 
            // timerClients
            // 
            this.timerClients.Tick += new System.EventHandler(this.timerClients_Tick);
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Location = new System.Drawing.Point(12, 12);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(141, 17);
            this.labelConnected.TabIndex = 7;
            this.labelConnected.Text = "Connected: OFFLINE";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 77);
            this.Controls.Add(this.labelConnected);
            this.Controls.Add(this.labelOnline);
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
        private System.Windows.Forms.Label labelOnline;
        private System.Windows.Forms.Timer timerClients;
        private System.Windows.Forms.Label labelConnected;
    }
}

