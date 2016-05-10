using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.Models
{
    public class ContactsModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string phone { get; set; }

        public string Email { get; set; }

        public DateTime LastModified { get; set; }
    }
}
