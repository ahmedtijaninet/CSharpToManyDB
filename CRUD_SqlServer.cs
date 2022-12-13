using System;
using System.Data.SqlClient;
namespace CRUDExample
{
class Program
{
static void Main(string[] args)
{
// Connect to the database
SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=MyDatabase;Integrated Security=True");
conn.Open();

        // Query the database
        string sql = "SELECT * FROM Customers WHERE City = 'New York'";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataReader reader = cmd.ExecuteReader();

        // Print the results
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }

        // Create a new customer
        sql = "INSERT INTO Customers (Name, City) VALUES (@Name, @City)";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Name", "John Doe");
        cmd.Parameters.AddWithValue("@City", "Los Angeles");
        cmd.ExecuteNonQuery();

        // Update an existing customer
        sql = "UPDATE Customers SET City = @City WHERE Name = @Name";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Name", "John Doe");
        cmd.Parameters.AddWithValue("@City", "San Francisco");
        cmd.ExecuteNonQuery();

        // Delete a customer
        sql = "DELETE FROM Customers WHERE Name = @Name";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Name", "John Doe");
        cmd.ExecuteNonQuery();

        // Close the connection
        conn.Close();
    }
}
}
