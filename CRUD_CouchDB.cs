


using System;
using CouchDB.Driver;

namespace CRUDExample
{
class Program
{
static void Main(string[] args)
{
// Connect to the database
CouchClient client = new CouchClient("http://localhost:5984", "my_database");

        // Query the database
        var query = client.Query<Customer>()
            .Where(c => c.City == "New York")
            .ToList();

        // Print the results
        foreach (var customer in query)
        {
            Console.WriteLine(customer.Name);
        }

        // Create a new customer
        Customer newCustomer = new Customer
        {
            Name = "John Doe",
            City = "Los Angeles"
        };
        client.CreateDocument(newCustomer);

        // Update an existing customer
        var existingCustomer = client.Query<Customer>()
            .Where(c => c.Name == "John Doe")
            .FirstOrDefault();
        existingCustomer.City = "San Francisco";
        client.UpdateDocument(existingCustomer);

        // Delete a customer
        var customerToDelete = client.Query<Customer>()
            .Where(c => c.Name == "John Doe")
            .FirstOrDefault();
        client.DeleteDocument(customerToDelete);
    }
}

// Class representing a customer in the database
public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
}
}


