using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Model
{
    public class MockContactsRepo : IContactsRepository
    {
        private int numContactsToGenerate = 55;
        private int indexCounter = 1;
        private List<Contact> contacts;

        public MockContactsRepo()
        {
            contacts = CreateContacts();
        }

        public int Create(Contact contact)
        {
            contact.Index = indexCounter++;
            contacts.Add(contact);
            return contact.Index;
        }

        public void Delete(int index)
        {
            if (contacts.Any(c => c.Index == index))
            {
                contacts.RemoveAll(c => c.Index == index);
            }
            else
            {
                throw new ArgumentException($"No contact found with index {index}.");
            }
        }

        public Contact Get(int index)
        {
            return contacts.FirstOrDefault(c => c.Index == index);
        }

        public IList<Contact> GetAll()
        {
            return contacts.ToList();
        }

        public void SaveChanges()
        {

        }

        public void Update(Contact contact)
        {
            Delete(contact.Index);
            contacts.Add(contact);
        }

        private List<Contact> CreateContacts()
        {
            var addresses = new List<string>
            {
                "Vänstervägen",
                "Högervägen",
                "Nedåtgatan",
                "Uppåtvägen",
                "Framvägen",
                "Bakgatan",
                "Uppfarten",
                "Nedförsbacken",
                "Testgränd",
                "Återvändsgränd",
            };
            var cities = new List<string>
            {
                "Göteborg",
                "Stockholm",
                "Arboga",
                "Cannes",
                "Delphi",
                "Metropolis",
                "Ankeborg",
                "Paris",
                "Hamburg",
                "Berlin",
            };
            var countries = new List<string>
            {
                "Sweden",
                "Germany",
                "Bali",
                "Finland",
                "Netherlands",
                "Libya",
                "South Africa",
                "Atlantis",
                "Ireland",
            };
            var emails = new List<string>
            {
                "noreply@mailsender.com",
                "ogiltig@adress.se",
                "john@mail.com",
                "david@mail.com",
                "greta@mail.com",
                "whinny@mail.com",
                "gurkan@hotmail.com",
            };
            var names = new List<string>
            {
                "John Smith",
                "Test Testsson",
                "Isak Abrahamsson",
                "Sven Hej",
                "Tom Bombadill",
                "Arsten Water",
                "Liz Other",
                "Bert Thune",
                "Horace Engberg",
                "Äng Fält",
                "Karl Älg",
                "Barbro Älg",
                "Lillan Gustavsson",
                "Johnny B Goode",
            };
            var phones = new List<string>
            {
                "010-20555665",
                "0731-4565322",
                "098-6543546",
                "031-6546578",
                "077-54654684",
                "901-465468",
                "112-45648465",
            };
            var appdata = new List<string>
            {
                "http://cdn.collider.com/wp-content/uploads/Venom-4.jpg",
                "https://pbs.twimg.com/profile_images/577915663781482496/28tCoxPH.jpeg",
                "https://c1.staticflickr.com/9/8086/8466271529_dc5c0a958f_z.jpg"

            };
            var contactList = new List<Contact>();
            Random rand = new Random();
            for (int i = 0; i < numContactsToGenerate; ++i)
            {
                contactList.Add(new Contact
                {
                    Name = names[(indexCounter - 1) % names.Count],
                    CareOf = rand.Next(0,4) < 1 ? $"c/o {names[(indexCounter) % names.Count]}" : string.Empty,
                    Address = $"{addresses[(indexCounter - 1) % addresses.Count]} {indexCounter}",
                    PostalCode = $"{indexCounter%10}{indexCounter%10}{indexCounter%10} {indexCounter%10}{indexCounter%10}",
                    City = cities[(indexCounter - 1) % cities.Count],
                    Country = countries[(indexCounter - 1) % countries.Count],
                    EmailAddress = emails[(indexCounter - 1) % emails.Count],
                    PhoneNumber = phones[(indexCounter - 1) % phones.Count],
                    AppData = appdata[(indexCounter - 1) % appdata.Count],
                    Index = indexCounter++
                }
                );
            }
            return contactList;
        }

    }
}
