using System.IO;
using Newtonsoft.Json;
using Data;

namespace Database
{
    public class Database
    {
        public Data.Data Data;
        public string Path;

        public Database()
        {
            Path = "db.txt";
            Load();
        }

        public void Load()
        {
            var json = File.ReadAllText(Path);
            Data = JsonConvert.DeserializeObject<Data.Data>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(Data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
            File.WriteAllText(Path, json);
        }

        public int AddUser(string name)
        {
            var user = new User(name, Data.AI_User++);
            Data.AddUser(user);
            Save();
            return user.Id;
        }

        public int AddCategory(string name)
        {
            var cat = new Category(name, Data.AI_Category++);
            Data.AddCategory(cat);
            Save();
            return cat.Id;
        }

        public int AddGood(string name)
        {
            var good = new Good(name, Data.AI_Good++);
            Data.AddGood(good);
            Save();
            return good.Id;
        }

        public bool RemoveUser(long userId)
        {
            if (Data.UserList.Exists(x => x.Id == userId))
            {
                Data.RemoveUser(Data.UserList.Find(x => x.Id == userId));
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCategory(long catId)
        {
            if (Data.CategoryList.Exists(x => x.Id == catId))
            {
                Data.RemoveCategory(Data.CategoryList.Find(x => x.Id == catId));
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveGood(long goodId)
        {
            if (Data.GoodList.Exists(x => x.Id == goodId))
            {
                Data.RemoveGood(Data.GoodList.Find(x => x.Id == goodId));
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
            return Data;
        }
    }
}
