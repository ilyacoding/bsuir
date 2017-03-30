using System;
using System.IO;
using System.Linq;
using Data;

namespace Database
{
    public class Database
    {
        public DbSerializer Serializer { get; set; }
        public Data.Data Data { get; set; }
        public string Path;

        public Database(string path, DbSerializer serializer)
        {
            Path = path;
            Serializer = serializer;
            Load();
        }

        public void Load()
        {
            var json = File.ReadAllText(Path);
            Data = Serializer.Deserialize(json);
        }

        public void Save()
        {
            var json = Serializer.Serialize(Data);
            File.WriteAllText(Path, json);
        }

        public bool AddReference(int goodId, int categoryId)
        {
            if (Data.ReferenceExist(goodId, categoryId)) throw new Exception("Reference already exist.");
            if (!Data.GoodExist(goodId)) throw new Exception("Good doesn't exist.");
            if (!Data.CategoryExist(categoryId)) throw new Exception("Category doesn't exist.");
            Data.AddReference(new Reference(goodId, categoryId));
            Save();
            return true;
        }

        public bool RemoveReference(int goodId, int categoryId)
        {
            if (!Data.ReferenceExist(goodId, categoryId)) throw new Exception("Reference doesn't exist.");
            Data.RemoveReference(goodId, categoryId);
            Save();
            return true;
        }

        public int AddUser(string name)
        {
            if (name.Length == 0) throw new Exception("User name not defined.");
            var user = new User(name, Data.AI_User++);
            Data.AddUser(user);
            Save();
            return user.Id;
        }

        public int AddCategory(string name, int userId)
        {
            if (name.Length == 0) throw new Exception("Category name not defined.");
            if (!Data.UserExist(userId)) throw new Exception("User doesn't exist.");
            var cat = new Category(name, userId, Data.AI_Category++);
            Data.AddCategory(cat);
            Save();
            return cat.Id;
        }

        public int AddGood(string name, int userId)
        {
            if (name.Length == 0) throw new Exception("Good name not defined.");
            if (!Data.UserExist(userId)) throw new Exception("User doesn't exist.");
            var good = new Good(name, userId, Data.AI_Good++);
            Data.AddGood(good);
            Save();
            return good.Id;
        }

        public bool RemoveUser(int userId)
        {
            if (!Data.UserExist(userId)) throw new Exception("User doesn't exist.");
            Data.RemoveUser(userId);
            Save();
            return true;
        }

        public bool RemoveCategory(int catId)
        {
            if (!Data.CategoryExist(catId)) throw new Exception("Category doesn't exist.");
            Data.RemoveReferenceByCategoryId(catId);
            Data.RemoveCategory(catId);
            Save();
            return true;
        }

        public bool RemoveGood(int goodId)
        {
            if (!Data.GoodExist(goodId)) throw new Exception("Good doesn't exist.");
            Data.RemoveReferenceByGoodId(goodId);
            Data.RemoveGood(goodId);
            Save();
            return true;
        }

        public Data.Data SelectByUserId(int userId, bool dependency)
        {
            var data = new Data.Data();

            if (!Data.UserExist(userId)) throw new Exception("User doesn't exist.");

            data.AddUser(Data.UserList.Single(x => x.Id == userId));

            if (!dependency) return data;

            foreach (var good in Data.GoodList.Where(x => x.UserId == userId).ToList())
            {
                data.AddGood(good);
            }

            foreach (var category in Data.CategoryList.Where(x => x.UserId == userId).ToList())
            {
                data.AddCategory(category);
            }

            return data;
        }

        public Data.Data SelectByGoodId(int goodId, bool dependency)
        {
            var data = new Data.Data();

            if (!Data.GoodExist(goodId)) throw new Exception("Good doesn't exist.");

            var good = Data.GoodList.Single(x => x.Id == goodId);

            data.AddGood(good);

            if (!dependency) return data;

            foreach (var user in Data.UserList.Where(x => x.Id == good.UserId).ToList())
            {
                data.AddUser(user);
            }

            foreach (var category in Data.SelectCategoryByGood(goodId).ToList())
            {
                data.AddCategory(category);
            }

            foreach (var reference in Data.ReferenceList.Where(x => x.GoodId == good.Id).ToList())
            {
                data.AddReference(reference);
            }

            return data;
        }

        public Data.Data SelectByCategoryId(int categoryId, bool dependency)
        {
            var data = new Data.Data();

            if (!Data.CategoryExist(categoryId)) throw new Exception("Category doesn't exist.");

            var category = Data.CategoryList.Single(x => x.Id == categoryId);
            data.AddCategory(category);
            
            if (!dependency) return data;

            foreach (var user in Data.UserList.Where(x => x.Id == category.UserId).ToList())
            {
                data.AddUser(user);
            }

            foreach (var good in Data.SelectGoodByCategory(categoryId).ToList())
            {
                data.AddGood(good);
            }

            foreach (var reference in Data.ReferenceList.Where(x => x.CategoryId == category.Id).ToList())
            {
                data.AddReference(reference);
            }

            return data;
        }

        public Data.Data GetData()
        {
            return Data;
        }
    }
}
