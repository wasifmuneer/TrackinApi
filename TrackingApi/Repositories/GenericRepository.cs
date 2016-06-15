using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingApi.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private MongoClient client = null;

        private IMongoCollection<T> _results = null;

        private string Connection = "";


        public GenericRepository()
        {
            Connection = ConfigurationManager.ConnectionStrings["MongoConnection"].ToString();

            client=new MongoClient (Connection);

            var db = client.GetDatabase("Contacts");

            _results = db.GetCollection<T>("T");
        }

        public virtual IEnumerable<T> Find()
        {
            return null;
        }

        public virtual void Insert(T model)
        {
            _results.InsertOneAsync(model);
        }

        public virtual bool Delete(T model)
        {
            //throw new NotImplementedException();
            return false;
        }

        public virtual bool Updatecontact(T model)
        {
            //throw new NotImplementedException();

            return false;
        }

        public virtual T Get(string id)
        {
            //throw new NotImplementedException();

            return null;
        }


       
    }
}
