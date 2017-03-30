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

            try
            {
                var response = Client.AddUser(userName);
                MessageBox.Show("User added. Id: " + response);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId;
            var catName = Interaction.InputBox("Category:", "Input category", "");
            try
            {
                userId = Convert.ToInt32(Interaction.InputBox("UserId:", "Input userId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("UserId must be integer.");
                return;
            }

            try
            {
                var response = Client.AddCategory(catName, userId);
                MessageBox.Show("Category added. Id: " + response);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void addGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId;
            var goodName = Interaction.InputBox("Goodname:", "Input good", "");
            try
            {
                userId = Convert.ToInt32(Interaction.InputBox("UserId:", "Input userId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("UserId must be integer.");
                return;
            }

            try
            {
                var response = Client.AddGood(goodName, userId);
                MessageBox.Show("Good added. Id: " + response);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
                
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId;
            try
            {
                userId = Convert.ToInt32(Interaction.InputBox("User Id:", "User to delete", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("UserId must be integer.");
                return;
            }

            try
            {
                var response = Client.RemoveUser(userId);
                if (response)
                    MessageBox.Show("User with id " + userId + " deleted succesfully.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void goodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int goodId;

            try
            {
                goodId = Convert.ToInt32(Interaction.InputBox("Good Id:", "Good to delete", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("GoodId must be integer.");
                return;
            }
            
            try
            {
                var response = Client.RemoveGood(goodId);
                if (response)
                    MessageBox.Show("Good with id " + goodId + " deleted succesfully.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int categoryId;

            try
            {
                categoryId = Convert.ToInt32(Interaction.InputBox("Category Id:", "Category to delete", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("CategoryId must be integer.");
                return;
            }

            try
            {
                var response = Client.RemoveCategory(categoryId);
                if (response)
                    MessageBox.Show("Category with id " + categoryId + " deleted succesfully.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        
        private void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int goodId;
            int categoryId;
            try
            {
                goodId = Convert.ToInt32(Interaction.InputBox("GoodId:", "Input goodId", ""));
                categoryId = Convert.ToInt32(Interaction.InputBox("CategoryId:", "Input categoryId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("GoodId and CategoryId must be integer.");
                return;
            }

            try
            {
                if (Client.AddReference(goodId, categoryId))
                    MessageBox.Show("Reference added: GoodId: " + goodId + ", CategoryId: " + categoryId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void referenceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int goodId;
            int categoryId;
            try
            {
                goodId = Convert.ToInt32(Interaction.InputBox("GoodId:", "Input goodId", ""));
                categoryId = Convert.ToInt32(Interaction.InputBox("CategoryId:", "Input categoryId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("GoodId and CategoryId must be integer.");
                return;
            }

            try
            {
                if (Client.RemoveReference(goodId, categoryId))
                    MessageBox.Show("Reference removed: GoodId: " + goodId + ", CategoryId: " + categoryId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void PrintData(Data.Data data)
        {
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

        private void loadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PrintData(Client.GetData());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void selectUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userId;
            bool dependency;
            try
            {
                userId = Convert.ToInt32(Interaction.InputBox("UserId:", "Input userId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("UserId must be integer.");
                return;
            }

            switch (Interaction.MsgBox("Select dependencies from database?", MsgBoxStyle.YesNo))
            {
                case MsgBoxResult.Yes:
                    dependency = true;
                    break;
                case MsgBoxResult.No:
                    dependency = false;
                    break;
                default:
                    MessageBox.Show("Please, select: choose dependency or not.");
                    return;
            }

            try
            {
                var response = Client.SelectByUserId(userId, dependency);
                PrintData(response);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void selectCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int categoryId;
            bool dependency;
            try
            {
                categoryId = Convert.ToInt32(Interaction.InputBox("CategoryId:", "Input categoryId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("CategoryId must be integer.");
                return;
            }

            switch (Interaction.MsgBox("Select dependencies from database?", MsgBoxStyle.YesNo))
            {
                case MsgBoxResult.Yes:
                    dependency = true;
                    break;
                case MsgBoxResult.No:
                    dependency = false;
                    break;
                default:
                    MessageBox.Show("Please, select: choose dependency or not.");
                    return;
            }

            try
            {
                var response = Client.SelectByCategoryId(categoryId, dependency);
                PrintData(response);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void selectGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int goodId;
            bool dependency;
            try
            {
                goodId = Convert.ToInt32(Interaction.InputBox("GoodId:", "Input goodId", ""));
            }
            catch (Exception)
            {
                MessageBox.Show("GoodId must be integer.");
                return;
            }

            switch (Interaction.MsgBox("Select dependencies from database?", MsgBoxStyle.YesNo))
            {
                case MsgBoxResult.Yes:
                    dependency = true;
                    break;
                case MsgBoxResult.No:
                    dependency = false;
                    break;
                default:
                    MessageBox.Show("Please, select: choose dependency or not.");
                    return;
            }

            try
            {
                var response = Client.SelectByGoodId(goodId, dependency);
                PrintData(response);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
