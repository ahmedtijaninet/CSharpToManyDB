using System;
using Npgsql;

namespace CRUDExample
{
class Program
{
static void Main(string[] args)
{
// Connect to the database
NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Database=mydatabase;User Id=myusername;Password=mypassword;");
conn.Open();

        // Query the database
        string sql = "SELECT * FROM Customers WHERE City = 'New York'";
        NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
        NpgsqlDataReader reader = cmd.ExecuteReader();

        // Print the results
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }

        // Create a new customer
        sql = "INSERT INTO Customers (Name, City) VALUES (@Name, @City)";
        cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Name", "John Doe");
        cmd.Parameters.AddWithValue("City", "Los Angeles");
        cmd.ExecuteNonQuery();

        // Update an existing customer
        sql = "UPDATE Customers SET City = @City WHERE Name = @Name";
        cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Name", "John Doe");
        cmd.Parameters.AddWithValue("City", "San Francisco");
        cmd.ExecuteNonQuery();

        // Delete a customer
        sql = "DELETE FROM Customers WHERE Name = @Name";
        cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Name", "John Doe");
        cmd.ExecuteNonQuery();

        // Close the connection
        conn.Close();
    }
}
}