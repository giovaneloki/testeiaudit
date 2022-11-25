using API.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Interface
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetPersonById(int id);
        Person UpdatePerson(Person person);
        int DeletePerson(int id);
        Person AddPerson(Person person);
        PersonAddress AddPersonAddress(PersonAddress address);
        int DeletePersonAddress(int id);
        PersonAddress UpdatePersonAddress(PersonAddress person);
    }
}
