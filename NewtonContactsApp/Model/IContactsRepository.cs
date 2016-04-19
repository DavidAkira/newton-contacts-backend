using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonContactsApp.Model
{
    public interface IContactsRepository
    {
        ObservableCollection<Contact> GetAll();

        Contact Get(int index);

        int Create(Contact contact);

        void Update(Contact contact);

        void Delete(int index);

        void SaveChanges();
    }
}
