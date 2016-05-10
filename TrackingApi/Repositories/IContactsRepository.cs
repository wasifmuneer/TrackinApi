using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackingApi.Entities;
using TrackingApi.Models;

namespace TrackingApi.Repositories
{
    public interface IContactsRepository
    {

        IEnumerable<Contact> getAllContacts();

        void Insert(ContactsModel model);

        bool Delete(ContactsModel model);

        bool Updatecontact(ContactsModel model);

        Contact GetContact(string id); 
   
    }
}
