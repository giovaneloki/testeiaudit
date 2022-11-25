using API.Domain.Entity;
using API.Repository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace API.Repository.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public PersonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public int AddPerson(Person person)
        {
            try
            {
                int id = 0;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var paramts = new {
                        Name = person.name,
                        Document = person.document,
                        Phone = person.phone,
                        DateBirthday = person.dateBirthday,
                    };

                    var result = conexao.Query<int>("sp_AddPerson", paramts, commandType: System.Data.CommandType.StoredProcedure);

                    id = result.First();

                    conexao.Close();
                }
                return id;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePerson(Person person)
        {
            try
            {
                int id = 0;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var paramts = new
                    {
                        Name = person.name,
                        Document = person.document,
                        Phone = person.phone,
                        DateBirthday = person.dateBirthday,
                        Id = person.id
                    };

                    var result = conexao.Query<int>("sp_UpdatePerson", paramts, commandType: System.Data.CommandType.StoredProcedure);

                    id = result.First();

                    conexao.Close();
                }
                return id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddPersonAddress(PersonAddress address)
        {
            try
            {
                int id = 0;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var paramts = new
                    {
                        PersonId = address.personId,
                        Street = address.street,
                        Neighborhood = address.neighborhood,
                        City = address.city,
                        PostalCode = address.postalCode,
                        Country = address.country
                    };

                    var result = conexao.Query<int>("sp_AddPersonAddress", paramts, commandType: System.Data.CommandType.StoredProcedure);

                    id = result.First();

                    conexao.Close();
                }
                return id;

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
                int idx = 0;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var paramts = new
                    {
                        Id = id
                    };

                    var result = conexao.Query<int>("sp_DeletePerson", paramts, commandType: System.Data.CommandType.StoredProcedure);

                    idx = result.First();

                    conexao.Close();
                }
                return idx;

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
                int idx = 0;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var paramts = new
                    {
                        Id = id
                    };

                    var result = conexao.Query<int>("sp_DeletePersonAddress", paramts, commandType: System.Data.CommandType.StoredProcedure);

                    idx = result.First();

                    conexao.Close();
                }
                return idx;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePersonAddress(PersonAddress address)
        {
            try
            {
                int id = 0;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var paramts = new
                    {
                        PersonId = address.personId,
                        Street = address.street,
                        Neighborhood = address.neighborhood,
                        City = address.city,
                        PostalCode = address.postalCode,
                        Country = address.country,
                        Id = address.id
                    };

                    var result = conexao.Query<int>("sp_UpdatePersonAddress", paramts, commandType: System.Data.CommandType.StoredProcedure);

                    id = result.First();

                    conexao.Close();
                }
                return id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Person> GetAll()
        {
            try
            {
                IEnumerable<Person> persons;

                using (var conexao = new SqlConnection(this._connectionString))
                {
                    conexao.Open();

                    var result = conexao.Query<(int Id, string Name, string Document, string Phone, DateTime DateBirthday, string _personAddressesJson)>("sp_GetAllPersons", commandType: System.Data.CommandType.StoredProcedure);

                    persons = result
                        .Select(p =>
                            new Person
                            {
                                id = p.Id,
                                name = p.Name,
                                document = p.Document,
                                phone = p.Phone,
                                dateBirthday = p.DateBirthday,
                                personAddresses = !string.IsNullOrEmpty(p._personAddressesJson) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<PersonAddress>>(p._personAddressesJson) :
                                Array.Empty<PersonAddress>().ToList()
                            })
                        .ToList();

                    conexao.Close();
                }

                return persons;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
