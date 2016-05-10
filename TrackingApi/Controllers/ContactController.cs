using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrackingApi.Entities;
using TrackingApi.Models;
using TrackingApi.Repositories;

namespace TrackingApi.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private readonly IContactsRepository _contacts = null;

        public ContactController()
        {
            _contacts = new ContactsRepository();
        }


        //public IQueryable<Contact> Get()
        //{
        //    return _contacts.getAllContacts().AsQueryable();
        //}

        //public ContactsModel Get(string id)
        //{
            

        //    var contact = _contacts.GetContact(id);

        //    if (contact == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound); 
        //    }

        //    var model = new ContactsModel() 
        //    { 
        //        Id=contact.Id
        //        ,
        //        Name=contact.Name
        //        ,
        //        Email=contact.Email
        //        ,
        //        LastModified=contact.LastModified
        //        ,
        //        phone=contact.phone
        //    };

        //    return model;
        //}
  
       public void  Post(ContactsModel value)
       {
            _contacts.Insert(value);

       }

       //GET api/Contact/GetAllContacts
       [Route("GetAllContacts")]
       public IEnumerable<ContactsModel> GetAllContact()
       {

           var list =_contacts.getAllContacts().ToList();

           var MODELS = new List<ContactsModel>();

           foreach (var CONTACT in list)
           {
               var model = new ContactsModel() 
               {
                   Id=CONTACT._id
                   ,
                   Email=CONTACT.Email
                   ,

                   Name=CONTACT.Name
                   ,
                   phone=CONTACT.phone
                   ,
                   LastModified=CONTACT.LastModified
               };

               MODELS.Add(model);
           }

           return MODELS;
       }

       //GET api/Contact/Get
       [Route("Get")]
       public PlatformModel Get()
       {
           var model = new PlatformModel() { Platform = "Mobile Platform" };

           return model;
       }
  //26:  
  //27:     public void Put(string id, Contact value)
  //28:     {
  //29:         if (!_contacts.UpdateContact(id, value))
  //30:         {
  //31:             throw new HttpResponseException(HttpStatusCode.NotFound);
  //32:         }
  //33:     }
  //34:  
  //35:     public void Delete(string id)
  //36:     {
  //37:         if (!_contacts.RemoveContact(id))
  //38:         {
  //39:             throw new HttpResponseException(HttpStatusCode.NotFound);
  //40:         }
  //41:     }

    }
}
