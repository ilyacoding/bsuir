using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using Command;

namespace TCPClient
{
    public partial class FormClient : Form
    {
        private RPC client { get; set; }

        public FormClient()
        {
            InitializeComponent();
        }
        
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client = new RPC();
            client.Connect(textBoxIP.Text, 17777);
            
            if (client.Connected())
            {
                labelConnected.Text = "Connected";
            }
            else
            {
                MessageBox.Show("Can't connect to server.");
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string UserName = Interaction.InputBox("Username:", "Input username", "");
            if (UserName.Length > 0)
            {
                var response = client.ProcessFunctuion(new AddUser(), new object[] { UserName });
                MessageBox.Show("User added. Id: " + response.ToString());
            }
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string CatName = Interaction.InputBox("Category:", "Input category", "");
            if (CatName.Length > 0)
            {
                var response = client.ProcessFunctuion(new AddCategory(), new object[] { CatName });
                MessageBox.Show("Category added. Id: " + response.ToString());
            }
        }

        private void addGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string GoodName = Interaction.InputBox("Goodname:", "Input good", "");
            if (GoodName.Length > 0)
            {
                var response = client.ProcessFunctuion(new AddGood(), new object[] { GoodName });
                MessageBox.Show("Good added. Id: " + response.ToString());
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User to delete", ""));
                if (UserId >= 0)
                {
                    var response = client.ProcessFunctuion(new RemoveUser(), new object[] { (Int32)UserId });
                    if (response.ToString() != "error")
                    {
                        MessageBox.Show("User with id " + UserId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("User with id " + UserId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void goodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good to delete", ""));
                if (GoodId >= 0)
                {
                    var response = client.ProcessFunctuion(new RemoveGood(), new object[] { (Int32)GoodId });
                    if (response.ToString() != "error")
                    {
                        MessageBox.Show("Good with id " + GoodId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Good with id " + GoodId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int CategoryId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category to delete", ""));
                if (CategoryId >= 0)
                {
                    var response = client.ProcessFunctuion(new RemoveCategory(), new object[] { (Int32)CategoryId });
                    if (response.ToString() != "error")
                    {
                        MessageBox.Show("Category with id " + CategoryId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category with id " + CategoryId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }

        private void catToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                var response = client.ProcessFunctuion(new AddCatToUser(), new object[] { UserId, CatId });
                if (response.ToString() != "error")
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

        private void goodToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                var response = client.ProcessFunctuion(new AddGoodToUser(), new object[] { UserId, GoodId });
                if (response.ToString() != "error")
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

        private void goodToCatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int CategoryId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                var response = client.ProcessFunctuion(new AddGoodToCat(), new object[] { CategoryId, GoodId });
                if (response.ToString() != "error")
                {
                    MessageBox.Show("Link CategoryId: " + CategoryId.ToString() + " | GoodId: " + GoodId.ToString() + " created succesfully.");
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

        private void catToGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                int CategoryId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
                var response = client.ProcessFunctuion(new AddCatToGood(), new object[] { GoodId, CategoryId });
                if (response.ToString() != "error")
                {
                    MessageBox.Show("Link CategoryId: " + CategoryId.ToString() + " | GoodId: " + GoodId.ToString() + " created succesfully.");
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
                var response = client.ProcessFunctuion(new RemoveCatFromUser(), new object[] { UserId, CatId });
                if (response.ToString() != "error")
                {
                    MessageBox.Show("Link CatId: " + CatId.ToString() + " | UserId: " + UserId.ToString() + " deleted succesfully.");
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
                var response = client.ProcessFunctuion(new RemoveGoodFromUser(), new object[] { UserId, GoodId });
                if (response.ToString() != "error")
                {
                    MessageBox.Show("Link GoodId: " + GoodId.ToString() + " | UserId: " + UserId.ToString() + " deleted succesfully.");
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
                int CatId = Convert.ToInt32(Interaction.InputBox("Cat Id:", "Cat", ""));
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                var response = client.ProcessFunctuion(new RemoveGoodFromCat(), new object[] { CatId, GoodId });
                if (response.ToString() != "error")
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

        private void catFromGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int GoodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Cat Id:", "Cat", ""));
                var response = client.ProcessFunctuion(new RemoveCatFromGood(), new object[] { GoodId, CatId });
                if (response.ToString() != "error")
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var response = client.ProcessFunctuion(new GetData(), new object[] { });

                if (response.ToString() == "error")
                {
                    MessageBox.Show(response.ToString());
                    return;
                }

                Data.Data data = (Data.Data)response;

                richTextBoxUser.Clear();
                richTextBoxGood.Clear();
                richTextBoxCategory.Clear();

                foreach (var item in data.UserList)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
