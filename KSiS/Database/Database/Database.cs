using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Database.Shop;

namespace Database
{
    public class Database
    {
        public Data data;
        public string path;

        public Database(string p)
        {
            data = new Data();
            path = p;
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

        public void Load()
        {
            string json = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<Data>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        }

        public int AddUser(string name)
        {
            var user = new User(name);
            data.AddUser(user);
            return user.Id;
        }

        public void AddCatToUser(int UserId, int CatId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.CategoryList.Exists(x => x.Id == CatId))
            {
                data.UserList.Find(x => x.Id == UserId).CategoryList.Add(CatId);
            }
        }

        public void AddGoodToUser(int UserId, int GoodId)
        {
            if (data.UserList.Exists(x => x.Id == UserId) && data.GoodList.Exists(x => x.Id == GoodId))
            {
                data.UserList.Find(x => x.Id == UserId).GoodList.Add(GoodId);
            }
        }

        public void RemoveCatFromUser(int UserId, int CatId)
        {
            try
            {
                data.UserList.Find(x => x.Id == UserId).CategoryList.Remove(CatId);
            }
            catch (Exception e)
            {

            }
        }

        public void RemoveGoodFromUser(int UserId, int GoodId)
        {
            try
            {
                data.UserList.Find(x => x.Id == UserId).GoodList.Remove(GoodId);
            }
            catch (Exception e)
            {

            }
        }

        public int AddCategory(string name)
        {
            var cat = new Category(name);
            data.AddCategory(cat);
            return cat.Id;
        }

        public int AddGood(string name)
        {
            var good = new Good(name);
            data.AddGood(good);
            return good.Id;
        }

        public void AddGoodAndCat(int CatId, int GoodId)
        {
            if (data.CategoryList.Exists(x => x.Id == CatId) && data.GoodList.Exists(x => x.Id == GoodId))
            {
                data.CategoryList.Find(x => x.Id == CatId).GoodList.Add(GoodId);
                data.GoodList.Find(x => x.Id == GoodId).CategoryList.Add(CatId);
            }
        }

        public void RemoveGoodAndCat(int CatId, int GoodId)
        {
            try
            {
                data.CategoryList.Find(x => x.Id == CatId).GoodList.Remove(GoodId);
            } catch(Exception e)
            {

            }
            try
            {
                data.GoodList.Find(x => x.Id == GoodId).CategoryList.Remove(CatId);
            } catch(Exception e)
            {

            }
        }

        public Data GetData()
        {
            return data;
        }
    }
}
