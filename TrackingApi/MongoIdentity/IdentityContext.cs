using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.MongoIdentity
{
    public class IdentityContext
    {

        public IdentityUser Users { get; set; }

        public IdentityRole Roles { get; set; }

        public IdentityContext()
        { 
        }


    }
}
