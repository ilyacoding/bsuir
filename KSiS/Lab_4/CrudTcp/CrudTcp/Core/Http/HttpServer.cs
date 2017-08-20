using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Controllers;
using CrudTcp.Core.Http.Action;
using CrudTcp.Serialization;

namespace CrudTcp.Core.Http
{
    public class HttpServer
    {
        private ControllersRegistry ControllerRegistry { get; set; }
        private SerializerRegistry SerializerRegistry { get; set; }
        
        private Request Request { get; set; }
        private Response Response { get; set; }
        private List<object> Parameters { get; set; }

        private IController Controller { get; set; }
        private MethodInfo ControllerMethod { get; set; }

        public HttpServer(ControllersRegistry controllersRegistry, SerializerRegistry serializerRegistry)
        {
            ControllerRegistry = controllersRegistry;
            SerializerRegistry = serializerRegistry;
        }

        public IHttpAction Execute(string str)
        {
            try
            {
                Request = new Request(str);
                Parameters = GetParameters();

                Controller = ControllerRegistry.Get(Request.Uri.Controller);

                try
                {
                    ControllerMethod = GetControllerMethod();
                }
                catch (Exception)
                {
                    return new MethodNotAllowed();
                }

                if (ControllerMethod.GetParameters().Length > 0 && Request.Body.Length > 0)
                {
                    var serializer = SerializerRegistry.Get(Request.GetField("Content-Type"));
                    var bodyType = ControllerMethod.GetParameters().Last().ParameterType;
                    Parameters[Parameters.Count - 1] = serializer.Deserialize((string)Parameters[Parameters.Count - 1], bodyType);
                }

                return (IHttpAction)ControllerMethod.Invoke(Controller, Request.Parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new BadRequest();
            }
        }

        public byte[] GetResponse(IHttpAction httpAction)
        {
            if (httpAction.Object != null)
            {
                var serializer = SerializerRegistry.Get(Request.GetField("Accept"));

                var datareq = Encoding.UTF8.GetBytes(serializer.Serialize(httpAction.Object, httpAction.Object.GetType()));

                Response = new Response(ResponseStatus.Get(httpAction.Code), datareq);
                Response.Fields.Add("Content-Type", serializer.Mime);
            }
            else
            {
                Response = new Response(ResponseStatus.Get(httpAction.Code), null);
            }

            return CreateByteResponse();
        }

        private MethodInfo GetControllerMethod()
        {
            var httpMethod = Request.Method.ToLower();
            var argumentCount = Parameters.Count;

            foreach (var method in Controller.GetType().GetMethods())
            {
                if (!method.Name.ToLower().StartsWith(httpMethod)) continue;
                if (method.GetParameters().Length != argumentCount) continue;

                return method;
            }

            throw new Exception();
        }

        private List<object> GetParameters()
        {
            var parameters = new List<object>();

            foreach (var parameter in Request.Uri.UrlParams)
            {
                try
                {
                    var par = Convert.ToInt32(parameter);
                    parameters.Add(par);
                }
                catch (Exception)
                {
                    parameters.Add(parameter);
                }
            }

            if (Request.Body.Length > 0)
            {
                parameters.Add(Request.Body);
            }

            return parameters;
        }

        private byte[] CreateByteResponse()
        {
            if (Response.Data != null)
            {
                Response.Fields.Add("Accept-ranges", "bytes");
                Response.Fields.Add("Content-Length", Response.Data.Length.ToString());
            }

            var data = $"{TcpServer.HttpVersion} {Response.Status}\r\n";

            foreach (var title in Response.Fields)
            {
                data += $"{title.Key}: {title.Value}\r\n";
            }

            data += "\r\n";

            return Response.Data != null ? Combine(Encoding.UTF8.GetBytes(data), Response.Data) : Encoding.UTF8.GetBytes(data);
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }
    }
}

