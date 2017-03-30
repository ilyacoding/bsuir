using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Data
    {
        public List<Reference> ReferenceList { get; set; }

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
            ReferenceList = new List<Reference>();
        }

        public bool ReferenceExist(int goodId, int categoryId)
        {
            return ReferenceList.Exists(x => x.CategoryId == categoryId && x.GoodId == goodId);
        }

        public bool UserExist(int userId)
        {
            return UserList.Exists(x => x.Id == userId);
        }

        public bool CategoryExist(int categoryId)
        {
            return CategoryList.Exists(x => x.Id == categoryId);
        }

        public bool GoodExist(int goodId)
        {
            return GoodList.Exists(x => x.Id == goodId);
        }

        public void AddReference(Reference refer)
        {
            ReferenceList.Add(refer);
        }
        
        public void RemoveReference(int goodId, int categoryId)
        {
            ReferenceList.Remove(ReferenceList.Find(x => x.GoodId == goodId && x.CategoryId == categoryId));
        }

        public void RemoveReferenceByGoodId(int goodId)
        {
            ReferenceList.RemoveAll(x => x.GoodId == goodId);
        }

        public void RemoveReferenceByCategoryId(int categoryId)
        {
            ReferenceList.RemoveAll(x => x.CategoryId == categoryId);
        }

        public IEnumerable<Reference> SelectReferenceByCategoryId(int categoryId)
        {
            return ReferenceList.Where(x => x.CategoryId == categoryId);
        }

        public IEnumerable<Reference> SelectReferenceByGoodId(int goodId)
        {
            return ReferenceList.Where(x => x.GoodId == goodId);
        }

        public List<Category> SelectCategoryByGood(int goodId)
        {
            var reference = SelectReferenceByGoodId(goodId);
            var categories = new List<Category>();
            foreach (var item in reference.ToList())
            {
                var cat = CategoryList.Single(x => x.Id == item.CategoryId);
                if (!categories.Contains(cat))
                {
                    categories.Add(cat);
                }
            }
            return categories;
        }

        public List<Good> SelectGoodByCategory(int categoryId)
        {
            var reference = SelectReferenceByCategoryId(categoryId);
            var goods = new List<Good>();
            foreach (var item in reference.ToList())
            {
                var good = GoodList.Single(x => x.Id == item.GoodId);
                if (!goods.Contains(good))
                {
                    goods.Add(good);
                }
            }
            return goods;
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

        public void RemoveUser(int userId)
        {
            UserList.Remove(UserList.Find(x => x.Id == userId));
        }

        public void RemoveGood(int goodId)
        {
            GoodList.Remove(GoodList.Find(x => x.Id == goodId));
        }

        public void RemoveCategory(int categoryId)
        {
            CategoryList.Remove(CategoryList.Find(x => x.Id == categoryId));
        }
    }
}
