using System;
using StackExchange.Redis;

namespace CRUDExample
{
class Program
{
static void Main(string[] args)
{
// Connect to the database
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
IDatabase db = redis.GetDatabase();
        // Query the database
        var customers = db.HashGetAll("customers");

        // Print the results
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.Name);
        }

        // Create a new customer
        HashEntry[] newCustomer = {
            new HashEntry("Name", "John Doe"),
            new HashEntry("City", "Los Angeles")
        };
        db.HashSet("customers", newCustomer);

        // Update an existing customer
        db.HashSet("customers", "City", "San Francisco");

        // Delete a customer
        db.HashDelete("customers", "Name");
    }
}
}
