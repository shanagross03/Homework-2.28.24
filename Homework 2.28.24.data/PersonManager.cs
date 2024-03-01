using System.Data.SqlClient;

namespace Homework_2._28._24.data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class PersonManager
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=HomeWork; Integrated Security=true;";

        public List<Person> GetPeople()
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM People";
            connection.Open();
            var reader = command.ExecuteReader();
            var people = new List<Person>();
            while (reader.Read())
            {
                people.Add(new()
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;

        }

        public void AddPerson(Person p)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO People (FirstName, LastName, Age) VALUES (@firstName, @lastName, @age)";
            command.Parameters.AddWithValue("@firstName", p.FirstName);
            command.Parameters.AddWithValue("@lastName", p.LastName);
            command.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void AddManyPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                AddPerson(p);
            }
        }

    }
}