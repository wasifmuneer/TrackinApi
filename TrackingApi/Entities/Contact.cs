using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.Entities
{
    public class Contact
    {
        [BsonId]
        public string _id { get; set; }

        public string Name { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public DateTime LastModified { get; set; }
    }
}
