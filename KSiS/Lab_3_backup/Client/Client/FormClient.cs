using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Newtonsoft.Json;
using Microsoft.VisualBasic;

namespace Client
{
    public partial class FormClient : Form
    {
        Data.Data data { get; set; }
        Database.DatabaseClient client { get; set; }

        public FormClient()
        {
            InitializeComponent();
            client = new Database.DatabaseClient("NetTcpBinding_IDatabase");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Load();
            string json = client.GetData();
            data = JsonConvert.DeserializeObject<Data.Data>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            richTextBoxUser.Clear();
            richTextBoxGood.Clear();
            richTextBoxCategory.Clear();

            foreach(var item in data.UserList)
            {
                richTextBoxUser.Text += "Id: " + item.Id + " | Name: " + item.Name + "\n";
                richTextBoxUser.Text += "Category: ";
                foreach (var cat in item.CategoryList)
                {
                    richTextBoxUser.Text += cat + "; ";
                }
                richTextBoxUser.Text += "Good: ";
                foreach (var good in item.GoodList)
                {
                    richTextBoxUser.Text += good + "; ";
                }
                richTextBoxUser.Text += "\n\n";
            }

            foreach (var item in data.CategoryList)
            {
                richTextBoxCategory.Text += "Id: " + item.Id + " | Name: " + item.Name + "\n";
                richTextBoxCategory.Text += "Good: ";
                foreach (var good in item.GoodList)
                {
                    richTextBoxCategory.Text += good + "; ";
                }
                richTextBoxCategory.Text += "\n\n";
            }

            foreach (var item in data.GoodList)
            {
                richTextBoxGood.Text += "Id: " + item.Id + " | Name: " + item.Name + "\n";
                richTextBoxGood.Text += "Category: ";
                foreach (var cat in item.CategoryList)
                {
                    richTextBoxGood.Text += cat + "; ";
                }
                richTextBoxGood.Text += "\n\n";
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string UserName = Interaction.InputBox("Username:", "Input username", "");
            if (UserName.Length > 0)
            {
                MessageBox.Show("User added. Id: " + client.AddUser(UserName).ToString());
            }
        }

        private void goodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string GoodName = Interaction.InputBox("Goodname:", "Input good", "");
            if (GoodName.Length > 0)
            {
                MessageBox.Show("User added. Id: " + client.AddGood(GoodName).ToString());
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CatName = Interaction.InputBox("Category:", "Input category", "");
            if (CatName.Length > 0)
            {
                MessageBox.Show("Category added. Id: " + client.AddCategory(CatName).ToString());
            }
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User to delete", ""));
                if (UserId >= 0)
                {
                    if (client.RemoveUser(UserId))
                    {
                        MessageBox.Show("User with id " + UserId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("User with id " + UserId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void goodToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good to delete", ""));
                if (GoodId >= 0)
                {
                    if (client.RemoveGood(GoodId))
                    {
                        MessageBox.Show("Good with id " + GoodId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Good with id " + GoodId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void categoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category to delete", ""));
                if (CatId >= 0)
                {
                    if (client.RemoveCategory(CatId))
                    {
                        MessageBox.Show("Category with id " + CatId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category with id " + CatId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void addCatToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                if (client.AddCatToUser(UserId, CatId))
                {
                    MessageBox.Show("Link CatId: " + CatId.ToString() + " | UserId: " + UserId.ToString() + " created succesfully.");
                }
                else
                {
                    MessageBox.Show("Link creation failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void addGoodToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                if (client.AddGoodToUser(UserId, GoodId))
                {
                    MessageBox.Show("Link GoodId: " + GoodId.ToString() + " | UserId: " + UserId.ToString() + " created succesfully.");
                }
                else
                {
                    MessageBox.Show("Link creation failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void addGoodToCarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                if (client.AddGoodToCat(CatId, GoodId))
                {
                    MessageBox.Show("Link CatId: " + CatId.ToString() + " | GoodId: " + GoodId.ToString() + " created succesfully.");
                }
                else
                {
                    MessageBox.Show("Link creation failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void addCatToGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                if (client.AddCatToGood(GoodId, CatId))
                {
                    MessageBox.Show("Link GoodId: " + GoodId.ToString() + " | CatId: " + CatId.ToString() + " created succesfully.");
                }
                else
                {
                    MessageBox.Show("Link creation failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void catFromUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                if (client.RemoveCatFromUser(UserId, CatId))
                {
                    MessageBox.Show("Link UserId: " + UserId.ToString() + " | CatId: " + CatId.ToString() + " deleted succesfully.");
                }
                else
                {
                    MessageBox.Show("Link deletion failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void goodFromUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                if (client.RemoveGoodFromUser(UserId, GoodId))
                {
                    MessageBox.Show("Link UserId: " + UserId.ToString() + " | GoodId: " + GoodId.ToString() + " deleted succesfully.");
                }
                else
                {
                    MessageBox.Show("Link deletion failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void goodFromCatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                if (client.RemoveGoodFromCat(CatId, GoodId))
                {
                    MessageBox.Show("Link CatId: " + CatId.ToString() + " | GoodId: " + GoodId.ToString() + " deleted succesfully.");
                }
                else
                {
                    MessageBox.Show("Link deletion failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void catFromGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                if (client.RemoveCatFromGood(GoodId, CatId))
                {
                    MessageBox.Show("Link GoodId: " + GoodId.ToString() + " | CatId: " + CatId.ToString() + " deleted succesfully.");
                }
                else
                {
                    MessageBox.Show("Link deletion failed.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }
    }
}
