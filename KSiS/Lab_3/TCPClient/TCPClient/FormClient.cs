using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TCPClient
{
    public partial class FormClient : Form
    {
        private Rpc Client { get; set; }

        public FormClient()
        {
            InitializeComponent();
        }
        
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client = new Rpc(new Serializer.Serializer());
            Client.Connect(textBoxIP.Text, 17777);
            
            if (Client.Connected())
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
            var userName = Interaction.InputBox("Username:", "Input username", "");
            if (userName.Length > 0)
            {
                var response = Client.AddUser(userName);
                MessageBox.Show("User added. Id: " + response.ToString());
            }
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catName = Interaction.InputBox("Category:", "Input category", "");
            if (catName.Length > 0)
            {
                var response = Client.AddCategory(catName);
                MessageBox.Show("Category added. Id: " + response.ToString());
            }
        }

        private void addGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var goodName = Interaction.InputBox("Goodname:", "Input good", "");
            if (goodName.Length > 0)
            {
                var response = Client.AddGood(goodName);
                MessageBox.Show("Good added. Id: " + response.ToString());
            }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = Convert.ToInt32(Interaction.InputBox("User Id:", "User to delete", ""));
                if (userId >= 0)
                {
                    var response = Client.RemoveUser(userId);
                    if (response)
                    {
                        MessageBox.Show("User with id " + userId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("User with id " + userId.ToString() + " doesn't exist.");
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
                var goodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good to delete", ""));
                if (goodId >= 0)
                {
                    var response = Client.RemoveGood(goodId);
                    if (response)
                    {
                        MessageBox.Show("Good with id " + goodId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Good with id " + goodId.ToString() + " doesn't exist.");
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
                var categoryId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category to delete", ""));
                if (categoryId >= 0)
                {
                    var response = Client.RemoveCategory(categoryId);
                    if (response)
                    {
                        MessageBox.Show("Category with id " + categoryId.ToString() + " deleted succesfully.");
                    }
                    else
                    {
                        MessageBox.Show("Category with id " + categoryId.ToString() + " doesn't exist.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No changes were done.");
            }
        }
        /*
        private void catToUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = Convert.ToInt32(Interaction.InputBox("User Id:", "User", ""));
                int CatId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category", ""));
               // var response = client.ProcessFunctuion(new AddCatToUser(), new object[] { UserId, CatId });
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
        */
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var data = Client.GetData();

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
