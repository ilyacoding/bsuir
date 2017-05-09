using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CrudTcp.Controllers;
using CrudTcp.Core.Http;
using CrudTcp.Core.Http.Action;
using CrudTcp.Serialization;

namespace CrudTcp.Core
{
    public class ControllerHandler
    {
        private ControllersRegistry ControllerRegistry { get; set; }
        private SerializerRegistry SerializerRegistry { get; set; }

        public ControllerHandler(ControllersRegistry controllersRegistry, SerializerRegistry serializerRegistry)
        {
            ControllerRegistry = controllersRegistry;
            SerializerRegistry = serializerRegistry;
        }

        //public List<MethodInfo> GetMethodsList(string httpMethod, IController controller)
        //{
        //    httpMethod = httpMethod.ToLower();
        //
        //    var methodInfo = new List<MethodInfo>(0);
        //
        //    foreach (var method in controller.GetType().GetMethods())
        //    {
        //        if (!method.Name.ToLower().StartsWith(httpMethod)) continue;
        //
        //        methodInfo.Add(method);
        //    }
        //
        //    return methodInfo;
        //}

        public MethodInfo GetMethod(IController controller, string httpMethod, int argumentCount)
        {
            httpMethod = httpMethod.ToLower();

            foreach (var method in controller.GetType().GetMethods())
            {
                if (!method.Name.ToLower().StartsWith(httpMethod)) continue;
                if (method.GetParameters().Length != argumentCount) continue;

                return method;
            }

            return null;
        }

        public byte[] Execute(string str)
        {
            IHttpAction responseObject;
            var request = new Request(SerializerRegistry);
            request.Parse(str);
            
            var controller = ControllerRegistry.Get(request.Uri.Controller);
            
            var controllerMethod = GetMethod(controller, request.Method, request.Parameters?.Length ?? 0);

            if (controllerMethod == null)
            {
                responseObject = new NotFound();
            }
            else
            {
                if (controllerMethod.GetParameters().Length > 0)
                {
                    try
                    {
                        request.ParseBody(controllerMethod.GetParameters().Last().ParameterType);
                    }
                    catch (Exception)
                    {
                        responseObject = new BadRequest();
                    }
                }
                responseObject = (IHttpAction)controllerMethod.Invoke(controller, request.Parameters);
            }

            Response response;
            
            if (responseObject.Object != null)
            {
                var serializer = SerializerRegistry.Get(request.GetField("Accept"));
                var datareq = Encoding.UTF8.GetBytes(serializer.Serialize(responseObject.Object));
                response = new Response(ResponseStatus.Get(responseObject.Code), datareq);
                response.Fields.Add("Content-type", serializer.Mime);
            }
            else
            {
                response = new Response(ResponseStatus.Get(responseObject.Code), null);
            }

            return CreateResponse(response);
        }

        public byte[] CreateResponse(Response response)
        {
            response.Fields.Add("Accept-ranges", "bytes");

            if (response.Data != null)
            {
                response.Fields.Add("Content-Length", response.Data.Length.ToString());
            }

            var data = $"{TcpServer.HttpVersion} {response.Status}\r\n";

            foreach (var title in response.Fields)
            {
                data += $"{title.Key}: {title.Value}\r\n";
            }
            
            data += "\r\n";

            return response.Data != null ? Combine(Encoding.UTF8.GetBytes(data), response.Data) : Encoding.UTF8.GetBytes(data);
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
