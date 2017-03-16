using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Database.Shop;

namespace Database
{
    public class Data
    {
        public List<Category> CategoryList { get; set; }
        
        public List<Good> GoodList { get; set; }
        
        public List<User> UserList { get; set; }

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
    }
}
