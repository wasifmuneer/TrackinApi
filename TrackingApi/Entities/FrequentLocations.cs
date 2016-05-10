using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Common;

namespace TrackingApi.Entities
{
    public class FrequentLocations
    {

        
        private Loc locations=null;
        public FrequentLocations()
        {
            locations = new Loc();
        }

        [BsonId]
        public string _id { get; set; }
        public string type { get; set; }

        public Loc coordinates { get { return locations; } set { locations = value; } }


        
    }
}
