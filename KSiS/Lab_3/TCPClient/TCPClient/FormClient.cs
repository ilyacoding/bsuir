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
            try
            {
                var catName = Interaction.InputBox("Category:", "Input category", "");
                var userId = Convert.ToInt32(Interaction.InputBox("UserId:", "Input userId", ""));
                if (catName.Length > 0 && userId > 0)
                {
                    var response = Client.AddCategory(catName, userId);
                    if (response == -1)
                        MessageBox.Show("Can't add category. Invalid userId.");
                    else
                        MessageBox.Show("Category added. Id: " + response.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured.");
            }
        }

        private void addGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var goodName = Interaction.InputBox("Goodname:", "Input good", "");
                var userId = Convert.ToInt32(Interaction.InputBox("UserId:", "Input userId", ""));
                if (goodName.Length > 0 && userId > 0)
                {
                    var response = Client.AddGood(goodName, userId);

                    if (response == -1)
                        MessageBox.Show("Can't add good. Invalid userId.");
                    else
                        MessageBox.Show("Good added. Id: " + response.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured.");
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
                MessageBox.Show("Error occured.");
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
                MessageBox.Show("Error occured.");
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
                MessageBox.Show("Error occured.");
            }
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var data = Client.GetData();

                richTextBoxUser.Clear();
                richTextBoxGood.Clear();
                richTextBoxCategory.Clear();
                richTextBoxReference.Clear();

                foreach (var item in data.UserList)
                {
                    richTextBoxUser.Text += "Id: " + item.Id + " | Name: " + item.Name + "\n\n";
                }

                foreach (var item in data.CategoryList)
                {
                    richTextBoxCategory.Text += "Id: " + item.Id + " | Name: " + item.Name + "\n";
                    richTextBoxCategory.Text += "UserId: " + item.UserId;
                    richTextBoxCategory.Text += "\n\n";
                }

                foreach (var item in data.GoodList)
                {
                    richTextBoxGood.Text += "Id: " + item.Id + " | Name: " + item.Name + "\n";
                    richTextBoxGood.Text += "UserId: " + item.UserId;
                    richTextBoxGood.Text += "\n\n";
                }

                foreach (var item in data.ReferenceList)
                {
                    richTextBoxReference.Text += "GoodId: " + item.GoodId + " | CategoryId: " + item.CategoryId + "\n\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
       

        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var goodId = Convert.ToInt32(Interaction.InputBox("GoodId:", "Input goodId", ""));
                var categoryId = Convert.ToInt32(Interaction.InputBox("CategoryId:", "Input categoryId", ""));
                if (goodId >= 0 && categoryId >= 0)
                {
                    if (Client.AddReference(goodId, categoryId))
                    {
                        MessageBox.Show("Reference added: GoodId: " + goodId.ToString() + ", CategoryId: " +
                                        categoryId.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Reference already exists or good or category doesn't exist: GoodId: " + goodId.ToString() + ", CategoryId: " +
                                        categoryId.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured.");
            }
        }

        private void referenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var goodId = Convert.ToInt32(Interaction.InputBox("GoodId:", "Input goodId", ""));
                var categoryId = Convert.ToInt32(Interaction.InputBox("CategoryId:", "Input categoryId", ""));
                if (goodId >= 0 && categoryId >= 0)
                {
                    if (Client.RemoveReference(goodId, categoryId))
                    {
                        MessageBox.Show("Reference removed: GoodId: " + goodId.ToString() + ", CategoryId: " +
                                        categoryId.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Reference doesn't exists: GoodId: " + goodId.ToString() + ", CategoryId: " +
                                        categoryId.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error occured.");
            }
        }
    }
}
