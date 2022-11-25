using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Domain.Entity;

namespace API.Repository.Interface
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        int UpdatePerson(Person person);
        int DeletePerson(int id);
        int AddPerson(Person person);
        int AddPersonAddress(PersonAddress address);
        int DeletePersonAddress(int id);
        int UpdatePersonAddress(PersonAddress address);
    }
}
