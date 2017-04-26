﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlogDB.Objects
{
    [JsonObject(IsReference = true)]
    public class User
    {
        public User()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
