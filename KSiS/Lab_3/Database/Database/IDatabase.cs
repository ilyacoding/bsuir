using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.ServiceModel;

namespace Database
{
    [ServiceContract]
    public interface IDatabase
    {
        [OperationContract]
        void Save();
        
        [OperationContract]
        void Load();

        [OperationContract]
        string GetData();


        [OperationContract]
        int AddUser(string name);

        [OperationContract]
        int AddCategory(string name);

        [OperationContract]
        int AddGood(string name);


        [OperationContract]
        bool RemoveUser(int UserId);

        [OperationContract]
        bool RemoveCategory(int CatId);

        [OperationContract]
        bool RemoveGood(int GoodId);


        [OperationContract]
        bool AddCatToUser(int UserId, int CatId);

        [OperationContract]
        bool AddGoodToUser(int UserId, int GoodId);
        
        [OperationContract]
        bool AddGoodToCat(int CatId, int GoodId);

        [OperationContract]
        bool AddCatToGood(int GoodId, int CatId);


        [OperationContract]
        bool RemoveCatFromUser(int UserId, int CatId);

        [OperationContract]
        bool RemoveGoodFromUser(int UserId, int GoodId);

        [OperationContract]
        bool RemoveGoodFromCat(int CatId, int GoodId);

        [OperationContract]
        bool RemoveCatFromGood(int GoodId, int CatId);
    }
}
