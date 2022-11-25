using API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Repository.Interface;
using API.Domain.Entity;

namespace API.Service.Implementation
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Person AddPerson(Person person)
        {
            try
            {
                int id = this._personRepository.AddPerson(person);
                return this._personRepository.GetAll().Where(p => p.id == id).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonAddress AddPersonAddress(PersonAddress address)
        {
            try
            {
                int id = this._personRepository.AddPersonAddress(address);
                return this._personRepository.GetAll().Where(p => p.id == address.personId).First().personAddresses.Where(add => add.id == id).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeletePerson(int id)
        {
            try
            {
                this._personRepository.DeletePerson(id);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeletePersonAddress(int id)
        {
            try
            {
                this._personRepository.DeletePersonAddress(id);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Person> GetAll()
        {
            return this._personRepository.GetAll();
        }

        public Person GetPersonById(int id)
        {
            var list = this.GetAll().Where(person => person.id == id);

            if (list.Any())
                return list.First();
            else
                return new Person();
        }

        public Person UpdatePerson(Person person)
        {
            try
            {
                int id = this._personRepository.UpdatePerson(person);
                return this._personRepository.GetAll().Where(p => p.id == id).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonAddress UpdatePersonAddress(PersonAddress address)
        {
            try
            {
                int id = this._personRepository.UpdatePersonAddress(address);
                return this._personRepository.GetAll().Where(p => p.id == address.personId).First().personAddresses.Where(add => add.id == id).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
