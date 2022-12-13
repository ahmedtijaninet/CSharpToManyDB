using System;
using Cassandra;

namespace CassandraCRUDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to Cassandra cluster
            var cluster = Cluster.Builder()
                                 .AddContactPoint("127.0.0.1")
                                 .Build();
            var session = cluster.Connect("mykeyspace");

            // CREATE
            // Insert a record into the users table
            var insertUser = "INSERT INTO users (user_id, name, email) VALUES (1, 'John Doe', 'john.doe@example.com')";
            session.Execute(insertUser);

            // READ
            // Select all records from the users table
            var selectUsers = "SELECT * FROM users";
            var users = session.Execute(selectUsers);

            foreach (var user in users)
            {
                Console.WriteLine("user_id: " + user["user_id"] + ", name: " + user["name"] + ", email: " + user["email"]);
            }

            // UPDATE
            // Update the email of a user
            var updateUser = "UPDATE users SET email = 'johndoe@example.com' WHERE user_id = 1";
            session.Execute(updateUser);

            // DELETE
            // Delete a user from the users table
            var deleteUser = "DELETE FROM users WHERE user_id = 1";
            session.Execute(deleteUser);
        }
    }
}
