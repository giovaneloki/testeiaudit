using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Domain.Entity
{
    public class PersonAddress
    {
        public int id { get; set; }
        public int personId { get; set; }
        public string street { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }

        public PersonAddress()
        {

        }
    }
}
