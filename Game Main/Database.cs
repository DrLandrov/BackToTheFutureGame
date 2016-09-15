using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Main
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    class Database
    {
        //replace with database link
        const string CONN_STRING = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = DKGameDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }

        // during prototyping stage we make methods that are
        // not yet implemented throw new NotImplementedException();
        public void AddPerson(Person p)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO PlayerHighscore (Name, Score) VALUES (@Name, @Score)"))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Score", p.Score);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> list = new List<Person>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM PlayerHighscore", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // column by name - the better (preferred) way
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string name = reader.GetString(reader.GetOrdinal("Name"));
                        int score = reader.GetInt32(reader.GetOrdinal("Score"));
                        Person p = new Person() { Id = id, Name = name, Score = score };
                        list.Add(p);

                    }
                }
            }
            return list;
        }

        public void UpdatePerson(Person p)
        {
            throw new NotImplementedException();
        }

    }
}