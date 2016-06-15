using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.MongoIdentity
{
    public class IdentityRole:IRole<string>
    {

        public IdentityRole()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        public IdentityRole(string username)
            : this()
        {
            Name = username;
        }

        [BsonId]
        public string Id { get; private set; }

        public string Name { get; set; }
    }
}
