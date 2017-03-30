using System;
using System.Text;
using System.Net.Sockets;
using Command;

namespace TCPClient
{
    public class Rpc
    {
        private TcpClient Client { get; }
        private NetworkStream Stream { get; set; }
        private Serializer.Serializer Serializer { get; }

        public Rpc(Serializer.Serializer serializer)
        {
            Client = new TcpClient();
            Serializer = serializer;
        }

        public bool Connect(string remoteIp, int port)
        {
            try
            {
                Client.Connect(remoteIp, port);
                Stream = Client.GetStream();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Connected()
        {
            return Client.Connected;
        }

        private void Send(string msg)
        {
            if (!Client.Connected) return;
            var buf = Encoding.UTF8.GetBytes(msg);
            Stream.Write(buf, 0, buf.Length);
        }

        private string Receive()
        {
            var msg = "";
            if (!Client.Connected) return msg;
            var buffer = new byte[256];
            while (Stream.DataAvailable || msg.Length == 0)
            {
                var bytesRead = Stream.Read(buffer, 0, buffer.Length);
                msg += Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }
            return msg;
        }

        private object ProcessFunctuion(ICommand cmd)
        {
            var json = Serializer.Serialize(cmd);
            Send(json);
            json = Receive();
            var response = Serializer.Deserialize(json);
            if (response.Exception != null) throw response.Exception;
            return response.Value;
        }

        public int AddUser(string userName)
        {
            return Convert.ToInt32(ProcessFunctuion(new AddUser { User = userName }));
        }

        public int AddGood(string goodName, int userId)
        {
            return Convert.ToInt32(ProcessFunctuion(new AddGood { Good = goodName, UserId = userId}));
        }

        public int AddCategory(string catName, int userId)
        {
            return Convert.ToInt32(ProcessFunctuion(new AddCategory { Category = catName, UserId = userId}));
        }

        public bool AddReference(int goodId, int categoryId)
        {
            return (bool)ProcessFunctuion(new AddReference { GoodId = goodId, CategoryId = categoryId });
        }

        public bool RemoveReference(int goodId, int categoryId)
        {
            return (bool)ProcessFunctuion(new RemoveReference { GoodId = goodId, CategoryId = categoryId });
        }

        public bool RemoveUser(int userId)
        {
            return (bool)ProcessFunctuion(new RemoveUser { UserId = userId });
        }

        public bool RemoveGood(int goodId)
        {
            return (bool)ProcessFunctuion(new RemoveGood { GoodId = goodId });
        }

        public bool RemoveCategory(int catId)
        {
            return (bool)ProcessFunctuion(new RemoveCategory { CatId = catId });
        }

        public Data.Data SelectByUserId(int userId, bool dependency)
        {
            return (Data.Data)ProcessFunctuion(new SelectByUserId { UserId = userId, Dependency = dependency});
        }

        public Data.Data SelectByGoodId(int goodId, bool dependency)
        {
            return (Data.Data)ProcessFunctuion(new SelectByGoodId { GoodId = goodId, Dependency = dependency });
        }

        public Data.Data SelectByCategoryId(int categoryId, bool dependency)
        {
            return (Data.Data)ProcessFunctuion(new SelectByCategoryId { CategoryId = categoryId, Dependency = dependency });
        }

        public Data.Data GetData()
        {
            return (Data.Data)ProcessFunctuion(new GetData());
        }
    }
}