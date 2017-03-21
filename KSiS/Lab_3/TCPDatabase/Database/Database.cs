using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Data;

namespace Database
{
    public class Database
    {
        public Data.Data data;
        public string path;

        public Database()
        {
            path = "db.txt";
            Load();
        }

        public void Load()
        {
            string json = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<Data.Data>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
            File.WriteAllText(path, json);
        }

        public int AddUser(string name)
        {
            var user = new User(name, data.AI_User++);
            data.AddUser(user);
            Save();
            return user.Id;
        }

        public int AddCategory(string name)
        {
            var cat = new Category(name, data.AI_Category++);
            data.AddCategory(cat);
            Save();
            return cat.Id;
        }

        public int AddGood(string name)
        {
            var good = new Good(name, data.AI_Good++);
            data.AddGood(good);
            Save();
            return good.Id;
        }

        public bool RemoveUser(Int64 UserId)
        {
            if (data.UserList.Exists(x => x.Id == UserId))
            {
                data.RemoveUser(data.UserList.Find(x => x.Id == UserId));
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCategory(Int64 CatId)
        {
            if (data.CategoryList.Exists(x => x.Id == CatId))
            {
                data.RemoveCategory(data.CategoryList.Find(x => x.Id == CatId));
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveGood(Int64 GoodId)
        {
            if (data.GoodList.Exists(x => x.Id == GoodId))
            {
                data.RemoveGood(data.GoodList.Find(x => x.Id == GoodId));
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        /*
        public bool AddCatToUser(Int64 UserId, Int64 CatId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.CategoryList.Exists(x => x.Id == (Int32)CatId) && (!data.UserList.Find(x => x.Id == UserId).CategoryList.Exists(x => x == (Int32)CatId)))
            {
                data.UserList.Find(x => x.Id == UserId).CategoryList.Add((Int32)CatId);
                Save();
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public bool AddGoodToUser(Int64 UserId, Int64 GoodId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.GoodList.Exists(x => x.Id == GoodId) && (!data.UserList.Find(x => x.Id == UserId).GoodList.Exists(x => x == (Int32)GoodId)))
            {
                data.UserList.Find(x => x.Id == UserId).GoodList.Add((Int32)GoodId);
                Save();
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public bool AddGoodToCat(Int64 CatId, Int64 GoodId)
        {
            if (data.CategoryList.Exists(x => x.Id == CatId) && data.GoodList.Exists(x => x.Id == GoodId) && (!data.CategoryList.Find(x => x.Id == CatId).GoodList.Exists(x => x == (Int32)CatId)))
            {
                data.CategoryList.Find(x => x.Id == CatId).GoodList.Add((Int32)GoodId);
                Save();
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public bool AddCatToGood(Int64 GoodId, Int64 CatId)
        {
            if (data.CategoryList.Exists(x => x.Id == CatId) && data.GoodList.Exists(x => x.Id == GoodId) && (!data.GoodList.Find(x => x.Id == GoodId).CategoryList.Exists(x => x == (Int32)CatId)))
            {
                data.GoodList.Find(x => x.Id == GoodId).CategoryList.Add((Int32)CatId);
                Save();
                return true;
            }
            else
            {
                throw new Exception();
            }
        }

        public bool RemoveCatFromUser(Int64 UserId, Int64 CatId)
        {
            if (data.UserList.Find(x => x.Id == UserId).CategoryList.Remove((Int32)CatId))
            {
                Save();
                return true;
            }
            throw new Exception();
        }

        public bool RemoveGoodFromUser(Int64 UserId, Int64 GoodId)
        {
            if (data.UserList.Find(x => x.Id == UserId).GoodList.Remove((Int32)GoodId))
            {
                Save();
                return true;
            }
            throw new Exception();
        }

        public bool RemoveGoodFromCat(Int64 CatId, Int64 GoodId)
        {
            if (data.CategoryList.Find(x => x.Id == CatId).GoodList.Remove((Int32)GoodId))
            {
                Save();
                return true;
            }
            throw new Exception();
        }

        public bool RemoveCatFromGood(Int64 GoodId, Int64 CatId)
        {
            if (data.GoodList.Find(x => x.Id == GoodId).CategoryList.Remove((Int32)CatId))
            {
                Save();
                return true;
            }
            throw new Exception();
        }
        */
        public Data.Data GetData()
        {
            return data;
        }
    }
}
