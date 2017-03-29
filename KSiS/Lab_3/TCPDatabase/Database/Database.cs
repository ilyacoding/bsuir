using System;
using System.IO;
using Newtonsoft.Json;
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
            if (Data.ReferenceExist(goodId, categoryId) || !Data.GoodExist(goodId) || !Data.CategoryExist(categoryId)) return false;
            Data.AddReference(new Reference(goodId, categoryId));
            Save();
            return true;
        }

        public bool RemoveReference(int goodId, int categoryId)
        {
            if (!Data.ReferenceExist(goodId, categoryId)) return false;
            Data.RemoveReference(goodId, categoryId);
            Save();
            return true;
        }

        public int AddUser(string name)
        {
            var user = new User(name, Data.AI_User++);
            Data.AddUser(user);
            Save();
            return user.Id;
        }

        public int AddCategory(string name, int userId)
        {
            if (!Data.UserExist(userId)) return -1;
            var cat = new Category(name, userId, Data.AI_Category++);
            Data.AddCategory(cat);
            Save();
            return cat.Id;
        }

        public int AddGood(string name, int userId)
        {
            if (!Data.UserExist(userId)) return -1;
            var good = new Good(name, userId, Data.AI_Good++);
            Data.AddGood(good);
            Save();
            return good.Id;
        }

        public bool RemoveUser(int userId)
        {
            if (Data.UserExist(userId))
            {
                Data.RemoveUser(userId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCategory(int catId)
        {
            if (Data.CategoryExist(catId))
            {
                Data.RemoveReferenceByCategoryId(catId);
                Data.RemoveCategory(catId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveGood(int goodId)
        {
            if (Data.GoodExist(goodId))
            {
                Data.RemoveReferenceByGoodId(goodId);
                Data.RemoveGood(goodId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Data.Data GetData()
        {
            return Data;
        }
    }
}
