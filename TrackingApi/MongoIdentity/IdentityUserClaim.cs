using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.MongoIdentity
{
    public class IdentityUserClaim
    {
        public IdentityUserClaim()
        {
        }

        public IdentityUserClaim(Claim claim)
        {
            Type = claim.Type;
            Value = claim.Value;
        }

        public string Type { get; set; }
        public string Value { get; set; }

        public Claim ToSecurityClaim()
        {
            return new Claim(Type, Value);
        }
    }
}
