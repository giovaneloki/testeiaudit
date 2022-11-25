using API.Domain.Entity;
using API.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Person> GetAll()
        {
            return _personService.GetAll();
        }

        [HttpPost]
        [Route("AddPerson")]
        public Person AddPerson(Person person)
        {
            return this._personService.AddPerson(person);
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public Person UpdatePerson(Person person)
        {
            return this._personService.UpdatePerson(person);
        }

        [HttpDelete]
        [Route("DeletePerson/{id}")]
        public int DeletePerson(int id)
        {
            return this._personService.DeletePerson(id);
        }

        [HttpPost]
        [Route("AddPersonAddress")]
        public PersonAddress AddPersonAddress(PersonAddress person)
        {
            return this._personService.AddPersonAddress(person);
        }

        [HttpPut]
        [Route("UpdatePersonAddress")]
        public PersonAddress UpdatePersonAddress(PersonAddress person)
        {
            return this._personService.UpdatePersonAddress(person);
        }

        [HttpDelete]
        [Route("DeletePersonAddress/{id}")]
        public int DeletePersonAddress(int id)
        {
            return this._personService.DeletePersonAddress(id);
        }

    }
}
