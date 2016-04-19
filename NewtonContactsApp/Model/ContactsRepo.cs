using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Model
{
    public class ContactsRepo : IContactsRepository
    {
        public void Init()
        {

        }

        public int Create(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public Contact Get(int index)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Contact> GetAll()
        {
            ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();

            contacts.Add(
                new Contact
                {
                    Address = "vägen 1",
                    Name = "David Kihlstrand",
                    CareOf = "Björn kihlstrand",
                    City = "Göteborg",
                    AppData = "http://cdn.collider.com/wp-content/uploads/Venom-4.jpg",
                    Country = "Sweden",
                    EmailAddress = "spam@spammail.com",
                    Index = 0,
                    PhoneNumber = "070000000",
                    PostalCode = "45521"
                });
            contacts.Add(
                new Contact
                {
                    Address = "vägen 2",
                    Name = "Annica Kihlstrand",
                    CareOf = "Derp kihlstrand",
                    City = "Stockholm",
                    AppData = "http://www.abc.net.au/news/image/7074102-3x2-940x627.jpg",
                    Country = "Norge",
                    EmailAddress = "spam@spammail.com",
                    Index = 1,
                    PhoneNumber = "123123123",
                    PostalCode = "11111"
                }); 
            return contacts;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
