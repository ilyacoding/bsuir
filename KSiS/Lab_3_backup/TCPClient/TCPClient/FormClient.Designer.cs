namespace TCPClient
{
    partial class FormClient
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.labelConnected = new System.Windows.Forms.Label();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catToUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodToUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodToCatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catToGoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catFromUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodFromUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodFromCatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catFromGoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxGood = new System.Windows.Forms.RichTextBox();
            this.richTextBoxUser = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCategory = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.addLinksToolStripMenuItem,
            this.removeLinksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(923, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUserToolStripMenuItem,
            this.addCategoryToolStripMenuItem,
            this.addGoodToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // addUserToolStripMenuItem
            // 
            this.addUserToolStripMenuItem.Name = "addUserToolStripMenuItem";
            this.addUserToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.addUserToolStripMenuItem.Text = "User";
            this.addUserToolStripMenuItem.Click += new System.EventHandler(this.addUserToolStripMenuItem_Click);
            // 
            // addCategoryToolStripMenuItem
            // 
            this.addCategoryToolStripMenuItem.Name = "addCategoryToolStripMenuItem";
            this.addCategoryToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.addCategoryToolStripMenuItem.Text = "Category";
            this.addCategoryToolStripMenuItem.Click += new System.EventHandler(this.addCategoryToolStripMenuItem_Click);
            // 
            // addGoodToolStripMenuItem
            // 
            this.addGoodToolStripMenuItem.Name = "addGoodToolStripMenuItem";
            this.addGoodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.addGoodToolStripMenuItem.Text = "Good";
            this.addGoodToolStripMenuItem.Click += new System.EventHandler(this.addGoodToolStripMenuItem_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(12, 53);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(122, 22);
            this.textBoxIP.TabIndex = 1;
            this.textBoxIP.Text = "192.168.231.1";
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Location = new System.Drawing.Point(12, 33);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(99, 17);
            this.labelConnected.TabIndex = 2;
            this.labelConnected.Text = "No connection";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.goodToolStripMenuItem,
            this.categoryToolStripMenuItem});
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // goodToolStripMenuItem
            // 
            this.goodToolStripMenuItem.Name = "goodToolStripMenuItem";
            this.goodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.goodToolStripMenuItem.Text = "Good";
            this.goodToolStripMenuItem.Click += new System.EventHandler(this.goodToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // addLinksToolStripMenuItem
            // 
            this.addLinksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catToUserToolStripMenuItem,
            this.goodToUserToolStripMenuItem,
            this.goodToCatToolStripMenuItem,
            this.catToGoodToolStripMenuItem});
            this.addLinksToolStripMenuItem.Name = "addLinksToolStripMenuItem";
            this.addLinksToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.addLinksToolStripMenuItem.Text = "AddLinks";
            // 
            // removeLinksToolStripMenuItem
            // 
            this.removeLinksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catFromUserToolStripMenuItem,
            this.goodFromUserToolStripMenuItem,
            this.goodFromCatToolStripMenuItem,
            this.catFromGoodToolStripMenuItem});
            this.removeLinksToolStripMenuItem.Name = "removeLinksToolStripMenuItem";
            this.removeLinksToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.removeLinksToolStripMenuItem.Text = "RemoveLinks";
            // 
            // catToUserToolStripMenuItem
            // 
            this.catToUserToolStripMenuItem.Name = "catToUserToolStripMenuItem";
            this.catToUserToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.catToUserToolStripMenuItem.Text = "CatToUser";
            this.catToUserToolStripMenuItem.Click += new System.EventHandler(this.catToUserToolStripMenuItem_Click);
            // 
            // goodToUserToolStripMenuItem
            // 
            this.goodToUserToolStripMenuItem.Name = "goodToUserToolStripMenuItem";
            this.goodToUserToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.goodToUserToolStripMenuItem.Text = "GoodToUser";
            this.goodToUserToolStripMenuItem.Click += new System.EventHandler(this.goodToUserToolStripMenuItem_Click);
            // 
            // goodToCatToolStripMenuItem
            // 
            this.goodToCatToolStripMenuItem.Name = "goodToCatToolStripMenuItem";
            this.goodToCatToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.goodToCatToolStripMenuItem.Text = "GoodToCat";
            this.goodToCatToolStripMenuItem.Click += new System.EventHandler(this.goodToCatToolStripMenuItem_Click);
            // 
            // catToGoodToolStripMenuItem
            // 
            this.catToGoodToolStripMenuItem.Name = "catToGoodToolStripMenuItem";
            this.catToGoodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.catToGoodToolStripMenuItem.Text = "CatToGood";
            this.catToGoodToolStripMenuItem.Click += new System.EventHandler(this.catToGoodToolStripMenuItem_Click);
            // 
            // catFromUserToolStripMenuItem
            // 
            this.catFromUserToolStripMenuItem.Name = "catFromUserToolStripMenuItem";
            this.catFromUserToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.catFromUserToolStripMenuItem.Text = "CatFromUser";
            this.catFromUserToolStripMenuItem.Click += new System.EventHandler(this.catFromUserToolStripMenuItem_Click);
            // 
            // goodFromUserToolStripMenuItem
            // 
            this.goodFromUserToolStripMenuItem.Name = "goodFromUserToolStripMenuItem";
            this.goodFromUserToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.goodFromUserToolStripMenuItem.Text = "GoodFromUser";
            this.goodFromUserToolStripMenuItem.Click += new System.EventHandler(this.goodFromUserToolStripMenuItem_Click);
            // 
            // goodFromCatToolStripMenuItem
            // 
            this.goodFromCatToolStripMenuItem.Name = "goodFromCatToolStripMenuItem";
            this.goodFromCatToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.goodFromCatToolStripMenuItem.Text = "GoodFromCat";
            this.goodFromCatToolStripMenuItem.Click += new System.EventHandler(this.goodFromCatToolStripMenuItem_Click);
            // 
            // catFromGoodToolStripMenuItem
            // 
            this.catFromGoodToolStripMenuItem.Name = "catFromGoodToolStripMenuItem";
            this.catFromGoodToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.catFromGoodToolStripMenuItem.Text = "CatFromGood";
            this.catFromGoodToolStripMenuItem.Click += new System.EventHandler(this.catFromGoodToolStripMenuItem_Click);
            // 
            // richTextBoxGood
            // 
            this.richTextBoxGood.Location = new System.Drawing.Point(12, 81);
            this.richTextBoxGood.Name = "richTextBoxGood";
            this.richTextBoxGood.Size = new System.Drawing.Size(449, 209);
            this.richTextBoxGood.TabIndex = 3;
            this.richTextBoxGood.Text = "";
            // 
            // richTextBoxUser
            // 
            this.richTextBoxUser.Location = new System.Drawing.Point(253, 313);
            this.richTextBoxUser.Name = "richTextBoxUser";
            this.richTextBoxUser.Size = new System.Drawing.Size(449, 209);
            this.richTextBoxUser.TabIndex = 4;
            this.richTextBoxUser.Text = "";
            // 
            // richTextBoxCategory
            // 
            this.richTextBoxCategory.Location = new System.Drawing.Point(467, 81);
            this.richTextBoxCategory.Name = "richTextBoxCategory";
            this.richTextBoxCategory.Size = new System.Drawing.Size(449, 209);
            this.richTextBoxCategory.TabIndex = 5;
            this.richTextBoxCategory.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Good";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "User";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 523);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxCategory);
            this.Controls.Add(this.richTextBoxUser);
            this.Controls.Add(this.richTextBoxGood);
            this.Controls.Add(this.labelConnected);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormClient";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGoodToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catToUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodToUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodToCatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catToGoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catFromUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodFromUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodFromCatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catFromGoodToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxGood;
        private System.Windows.Forms.RichTextBox richTextBoxUser;
        private System.Windows.Forms.RichTextBox richTextBoxCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

