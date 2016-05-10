using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TrackingApi.Entities;
using TrackingApi.Models;
using MongoDB.Bson;
using System.Configuration;

namespace TrackingApi.Repositories
{
    public class ContactsRepository:IContactsRepository
    {
        private readonly string connection = "";

        private MongoClient client = null;

        private IMongoCollection<Contact> _contacts = null;

        public ContactsRepository()
        {
            //connection = "mongodb://localhost:27017";
            connection = ConfigurationManager.ConnectionStrings["MongoConnection"].ToString();

            client = new MongoClient(connection);

            var database = client.GetDatabase("Contacts");

            _contacts = database.GetCollection<Contact>("Contact");


            //_contacts.RemoveAll();

            //var filter = new Contact();

            _contacts.DeleteMany(_=>true);

            for (int i =1; i <5 ;i++)
            {
                ContactsModel model=new ContactsModel ()
                {
                    Email = string.Format("test{0}@example.com", i),
                    Name = string.Format("test{0}", i),
                    phone = string.Format("{0}{0}{0} {0}{0}{0} {0}{0}{0}{0}", i),
                    LastModified=DateTime.UtcNow
                };

                Insert(model);
            }




        }

        public IEnumerable<Entities.Contact> getAllContacts()
        {
            //var list = _contacts.Find(_=> true).ToList();

            return _contacts.Find(_ => true).ToList();
        }

        public void  Insert(Models.ContactsModel model)
        {
            
            var contact = new Contact() 
            { 
                _id=ObjectId.GenerateNewId().ToString ()
                ,
                Email=model.Email
                , 
                LastModified=model.LastModified
                ,
                Name=model.Name
                ,
                phone=model.phone
            };


            _contacts.InsertOne(contact);

            //return item;

        }

        public bool Delete(Models.ContactsModel model)
        {
            return true;
        }

        public bool Updatecontact(Models.ContactsModel model)
        {
            return true;
        }

        public Entities.Contact GetContact(string id)
        {
            return null;
        }


        
  // 1: public IEnumerable<Contact> GetAllContacts()
  // 2: {
  // 3:     return _contacts.FindAll();
  // 4: }
  // 5:  
  // 6: public Contact GetContact(string id)
  // 7: {
  // 8:     IMongoQuery query = Query.EQ("_id", id);
  // 9:     return _contacts.Find(query).FirstOrDefault();
  //10: }
  //11:  
  //12: public Contact AddContact(Contact item)
  //13: {
  //14:     item.Id = ObjectId.GenerateNewId().ToString();
  //15:     item.LastModified = DateTime.UtcNow;
  //16:     _contacts.Insert(item);
  //17:     return item;
  //18: }
  //19:  
  //20: public bool RemoveContact(string id)
  //21: {
  //22:     IMongoQuery query = Query.EQ("_id", id);
  //23:     SafeModeResult result = _contacts.Remove(query);
  //24:     return result.DocumentsAffected == 1;
  //25: }
  //26:  
  //27: public bool UpdateContact(string id, Contact item)
  //28: {
  //29:     IMongoQuery query = Query.EQ("_id", id);
  //30:     item.LastModified = DateTime.UtcNow;
  //31:     IMongoUpdate update = Update
  //32:         .Set("Email", item.Email)
  //33:         .Set("LastModified", DateTime.UtcNow)
  //34:         .Set("Name", item.Name)
  //35:         .Set("Phone", item.Phone);
  //36:     SafeModeResult result = _contacts.Update(query, update);
  //37:     return result.UpdatedExisting;
  //38: }
    }
}
