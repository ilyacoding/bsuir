using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDApplication.Controllers
{
    public class TopicController : ApiController
    {
        public ICollection<Topic> Get()
        {
            return new Collection<Topic>
            {
                new Topic { Id = 1, Title = "Топик 1"},
                new Topic { Id = 2, Title = "Топик 2"}
            };
        }
    }
}
