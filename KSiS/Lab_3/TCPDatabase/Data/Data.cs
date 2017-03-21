using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Data
    {
        public List<Category> CategoryList { get; set; }
        public int AI_Category;

        public List<Good> GoodList { get; set; }
        public int AI_Good;

        public List<User> UserList { get; set; }
        public int AI_User;


        public Data()
        {
            CategoryList = new List<Category>();
            GoodList = new List<Good>();
            UserList = new List<User>();
        }

        public void AddUser(User usr)
        {
            UserList.Add(usr);
        }

        public void AddGood(Good good)
        {
            GoodList.Add(good);
        }

        public void AddCategory(Category cat)
        {
            CategoryList.Add(cat);
        }

        public void RemoveUser(User usr)
        {
            UserList.Remove(usr);
        }

        public void RemoveGood(Good good)
        {
            GoodList.Remove(good);
        }

        public void RemoveCategory(Category cat)
        {
            CategoryList.Remove(cat);
        }
    }
}
