using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entity
{
    public class Person
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string document { get; set; }
        public string phone { get; set; }
        public DateTime dateBirthday { get; set; }
        public IEnumerable<PersonAddress> personAddresses { get; set; }
        //public string _personAddressesJson { get; set; }

        public Person()
        {

        }
    }
}
