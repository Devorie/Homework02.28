using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02._28_b_.Data
{
    namespace HomeWork_02._28.Data
    {
        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDay { get; set; }
        }

        public class PersonManager
        {
            private string _connectionString;

            public PersonManager(string connectionString)
            {
                _connectionString = connectionString;
            }

            public List<Person> GetPersons()
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                connection.Open();
                List<Person> people = new List<Person>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    people.Add(new Person
                    {
                        Id = (int)reader["EmployeeID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        BirthDay = (DateTime)reader["BirthDate"]
                    });
                }

                return people;
            }

            public void AddPerson(Person p)
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Employees (FirstName, LastName, BirthDate) " +
                            "VALUES (@firstName, @lastName, @birthDate)";
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@birthDate", p.BirthDay);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

            public void Add(List<Person> persons)
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                SqlCommand cmd = connection.CreateCommand();
                connection.Open();
                foreach (Person p in persons)
                {
                    if (p.FirstName != null && p.LastName != null && p.BirthDay != null)
                    {
                        AddPerson(p);
                    }
                }
            }
        }
    }
}
