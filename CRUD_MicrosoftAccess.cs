using System;
using System.Data.OleDb;

namespace CRUDExample
{
class Program
{
static void Main(string[] args)
{
// Connect to the database
OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\MyDatabase.accdb;Persist Security Info=False;");
conn.Open();

        // Query the database
        string sql = "SELECT * FROM Customers WHERE City = 'New York'";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataReader reader = cmd.ExecuteReader();

        // Print the results
        while (reader.Read())
        {
            Console.WriteLine(reader["Name"]);
        }

        // Create a new customer
        sql = "INSERT INTO Customers (Name, City) VALUES (?, ?)";
        cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddWithValue("Name", "John Doe");
        cmd.Parameters.AddWithValue("City", "Los Angeles");
        cmd.ExecuteNonQuery();

        // Update an existing customer
        sql = "UPDATE Customers SET City = ? WHERE Name = ?";
        cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddWithValue("Name", "John Doe");
        cmd.Parameters.AddWithValue("City", "San Francisco");
        cmd.ExecuteNonQuery();

        // Delete a customer
        sql = "DELETE FROM Customers WHERE Name = ?";
        cmd = new OleDbCommand(sql, conn);
        cmd.Parameters.AddWithValue("Name", "John Doe");
        cmd.ExecuteNonQuery();

        // Close the connection
        conn.Close();
    }
}
}





