using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlogDB.Objects
{
    [JsonObject(IsReference = true)]
    [DataContract(IsReference = true)]
    public class User
    {
        public User()
        {
            
        }

        [Key]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
