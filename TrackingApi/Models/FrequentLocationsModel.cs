using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Common;

namespace TrackingApi.Models
{
    public class FrequentLocationsModel
    {

        private  Loc locations=null;
        public FrequentLocationsModel()
        {
            locations = new Loc();
        }

        public string type { get; set; }

        public Loc coordinates { get { return locations; } set { locations = value; } }

        
    }
}
