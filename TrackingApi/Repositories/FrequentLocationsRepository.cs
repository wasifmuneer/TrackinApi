using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Entities;

namespace TrackingApi.Repositories
{
    public class FrequentLocationsRepository:IFrequentLocationsRepository
    {

        private readonly string connection = "";

        private MongoClient client = null;

        private IMongoCollection<FrequentLocations> _locations = null;

        public FrequentLocationsRepository()
        {

            connection = ConfigurationManager.ConnectionStrings["MongoConnection"].ToString();

            client = new MongoClient(connection);

            var database = client.GetDatabase("Contacts");

            _locations = database.GetCollection<FrequentLocations>("FrequentLocations");
        }

        public IEnumerable<Entities.FrequentLocations> getAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Models.FrequentLocationsModel model)
        {
            try
            {
                var entity = new FrequentLocations() {_id=ObjectId.GenerateNewId().ToString (), type = model.type, coordinates = model.coordinates };

                _locations.InsertOne(entity);
            }
            catch (Exception ex)
            {
 
            }

            //throw new NotImplementedException();
        }

        public bool Delete(Models.FrequentLocationsModel model)
        {
            throw new NotImplementedException();
        }

        public bool Updatecontact(Models.FrequentLocationsModel model)
        {
            throw new NotImplementedException();
        }

        public Entities.FrequentLocations GetLocation(string id)
        {
            throw new NotImplementedException();
        }
    }
}
