using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Entities;
using TrackingApi.Models;

namespace TrackingApi.Repositories
{
    public interface IFrequentLocationsRepository
    {
        IEnumerable<FrequentLocations> getAll();

        void Insert(FrequentLocationsModel model);

        bool Delete(FrequentLocationsModel model);

        bool Updatecontact(FrequentLocationsModel model);

        FrequentLocations GetLocation(string id); 
    }
}
