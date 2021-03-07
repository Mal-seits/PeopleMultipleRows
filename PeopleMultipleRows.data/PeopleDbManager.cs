using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace PeopleMultipleRows.data
{
    public class PeopleDbManager
    {
        private string _connectionString;
        public PeopleDbManager(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetAllPeople()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM People";
                connection.Open();
                var reader = command.ExecuteReader();
                List<Person> peopleList = new List<Person>();
                while (reader.Read())
                {
                    peopleList.Add(new Person
                    {
                        Id = (int)reader["id"],
                        FirstName = (string)reader["firstName"],
                        LastName = (string)reader["lastName"],
                        Age = (int)reader["age"]
                    });
                }
                return peopleList;
            }
        }
        public void AddPerson(List<Person> list)
        {
            foreach (Person p in list)
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = @"INSERT INTO People(FirstName, LastName, Age)
                                            VALUES (@firstName, @lastName, @age)";
                    command.Parameters.AddWithValue("@firstName", p.FirstName);
                    command.Parameters.AddWithValue("@lastName", p.LastName);
                    command.Parameters.AddWithValue("@age", p.Age);
                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
