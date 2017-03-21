namespace Client
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.goodToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatToUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGoodToUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGoodToCarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCatToGoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catFromUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodFromUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goodFromCatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catFromGoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBoxUser = new System.Windows.Forms.RichTextBox();
            this.richTextBoxGood = new System.Windows.Forms.RichTextBox();
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
            this.itemToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.linksToolStripMenuItem,
            this.removeLinksToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.goodToolStripMenuItem,
            this.categoryToolStripMenuItem});
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.itemToolStripMenuItem.Text = "Add";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // goodToolStripMenuItem
            // 
            this.goodToolStripMenuItem.Name = "goodToolStripMenuItem";
            this.goodToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.goodToolStripMenuItem.Text = "Good";
            this.goodToolStripMenuItem.Click += new System.EventHandler(this.goodToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.categoryToolStripMenuItem.Text = "Category";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem1,
            this.goodToolStripMenuItem1,
            this.categoryToolStripMenuItem1});
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // userToolStripMenuItem1
            // 
            this.userToolStripMenuItem1.Name = "userToolStripMenuItem1";
            this.userToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.userToolStripMenuItem1.Text = "User";
            this.userToolStripMenuItem1.Click += new System.EventHandler(this.userToolStripMenuItem1_Click);
            // 
            // goodToolStripMenuItem1
            // 
            this.goodToolStripMenuItem1.Name = "goodToolStripMenuItem1";
            this.goodToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.goodToolStripMenuItem1.Text = "Good";
            this.goodToolStripMenuItem1.Click += new System.EventHandler(this.goodToolStripMenuItem1_Click);
            // 
            // categoryToolStripMenuItem1
            // 
            this.categoryToolStripMenuItem1.Name = "categoryToolStripMenuItem1";
            this.categoryToolStripMenuItem1.Size = new System.Drawing.Size(144, 26);
            this.categoryToolStripMenuItem1.Text = "Category";
            this.categoryToolStripMenuItem1.Click += new System.EventHandler(this.categoryToolStripMenuItem1_Click);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCatToUserToolStripMenuItem,
            this.addGoodToUserToolStripMenuItem,
            this.addGoodToCarToolStripMenuItem,
            this.addCatToGoodToolStripMenuItem});
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.linksToolStripMenuItem.Text = "AddLinks";
            // 
            // addCatToUserToolStripMenuItem
            // 
            this.addCatToUserToolStripMenuItem.Name = "addCatToUserToolStripMenuItem";
            this.addCatToUserToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.addCatToUserToolStripMenuItem.Text = "CatToUser";
            this.addCatToUserToolStripMenuItem.Click += new System.EventHandler(this.addCatToUserToolStripMenuItem_Click);
            // 
            // addGoodToUserToolStripMenuItem
            // 
            this.addGoodToUserToolStripMenuItem.Name = "addGoodToUserToolStripMenuItem";
            this.addGoodToUserToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.addGoodToUserToolStripMenuItem.Text = "GoodToUser";
            this.addGoodToUserToolStripMenuItem.Click += new System.EventHandler(this.addGoodToUserToolStripMenuItem_Click);
            // 
            // addGoodToCarToolStripMenuItem
            // 
            this.addGoodToCarToolStripMenuItem.Name = "addGoodToCarToolStripMenuItem";
            this.addGoodToCarToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.addGoodToCarToolStripMenuItem.Text = "GoodToCat";
            this.addGoodToCarToolStripMenuItem.Click += new System.EventHandler(this.addGoodToCarToolStripMenuItem_Click);
            // 
            // addCatToGoodToolStripMenuItem
            // 
            this.addCatToGoodToolStripMenuItem.Name = "addCatToGoodToolStripMenuItem";
            this.addCatToGoodToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.addCatToGoodToolStripMenuItem.Text = "CatToGood";
            this.addCatToGoodToolStripMenuItem.Click += new System.EventHandler(this.addCatToGoodToolStripMenuItem_Click);
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
            // richTextBoxUser
            // 
            this.richTextBoxUser.Location = new System.Drawing.Point(489, 51);
            this.richTextBoxUser.Name = "richTextBoxUser";
            this.richTextBoxUser.Size = new System.Drawing.Size(469, 218);
            this.richTextBoxUser.TabIndex = 3;
            this.richTextBoxUser.Text = "";
            // 
            // richTextBoxGood
            // 
            this.richTextBoxGood.Location = new System.Drawing.Point(12, 51);
            this.richTextBoxGood.Name = "richTextBoxGood";
            this.richTextBoxGood.Size = new System.Drawing.Size(471, 218);
            this.richTextBoxGood.TabIndex = 4;
            this.richTextBoxGood.Text = "";
            // 
            // richTextBoxCategory
            // 
            this.richTextBoxCategory.Location = new System.Drawing.Point(257, 297);
            this.richTextBoxCategory.Name = "richTextBoxCategory";
            this.richTextBoxCategory.Size = new System.Drawing.Size(471, 218);
            this.richTextBoxCategory.TabIndex = 5;
            this.richTextBoxCategory.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Goods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Categories";
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 546);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxCategory);
            this.Controls.Add(this.richTextBoxGood);
            this.Controls.Add(this.richTextBoxUser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormClient";
            this.Text = "DatabaseClient";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBoxUser;
        private System.Windows.Forms.RichTextBox richTextBoxGood;
        private System.Windows.Forms.RichTextBox richTextBoxCategory;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem goodToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCatToUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGoodToUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGoodToCarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCatToGoodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catFromUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodFromUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goodFromCatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catFromGoodToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

