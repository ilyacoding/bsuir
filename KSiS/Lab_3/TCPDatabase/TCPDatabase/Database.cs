using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Data;

namespace TCPDatabase
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

        public bool RemoveUser(int UserId)
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

        public bool RemoveCategory(int CatId)
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

        public bool RemoveGood(int GoodId)
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

        public bool AddCatToUser(int UserId, int CatId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.CategoryList.Exists(x => x.Id == CatId))
            {
                data.UserList.Find(x => x.Id == UserId).CategoryList.Add(CatId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddGoodToUser(int UserId, int GoodId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.GoodList.Exists(x => x.Id == GoodId))
            {
                data.UserList.Find(x => x.Id == UserId).GoodList.Add(GoodId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddGoodToCat(int CatId, int GoodId)
        {
            if (data.CategoryList.Exists(x => x.Id == CatId) && data.GoodList.Exists(x => x.Id == GoodId))
            {
                data.CategoryList.Find(x => x.Id == CatId).GoodList.Add(GoodId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddCatToGood(int GoodId, int CatId)
        {
            if (data.CategoryList.Exists(x => x.Id == CatId) && data.GoodList.Exists(x => x.Id == GoodId))
            {
                data.GoodList.Find(x => x.Id == GoodId).CategoryList.Add(CatId);
                Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCatFromUser(int UserId, int CatId)
        {
            try
            {
                if (data.UserList.Find(x => x.Id == UserId).CategoryList.Remove(CatId))
                {
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveGoodFromUser(int UserId, int GoodId)
        {
            try
            {
                if (data.UserList.Find(x => x.Id == UserId).GoodList.Remove(GoodId))
                {
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveGoodFromCat(int CatId, int GoodId)
        {
            try
            {
                if (data.CategoryList.Find(x => x.Id == CatId).GoodList.Remove(GoodId))
                {
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCatFromGood(int GoodId, int CatId)
        {
            try
            {
                if (data.GoodList.Find(x => x.Id == GoodId).CategoryList.Remove(CatId))
                {
                    Save();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetData()
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            });
        }
    }
}
