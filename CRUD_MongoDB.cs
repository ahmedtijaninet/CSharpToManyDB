using System;
using MongoDB.Driver;

namespace CRUDExample
{
class Program
{
static void Main(string[] args)
{
// Connect to the database
MongoClient client = new MongoClient("mongodb://localhost:27017");
IMongoDatabase db = client.GetDatabase("myDatabase");


        // Query the database
        var customers = db.GetCollection<Customer>("customers").Find(c => c.City == "New York").ToList();

        // Print the results
        foreach (var customer in customers)
        {
            Console.WriteLine(customer.Name);
        }

        // Create a new customer
        Customer newCustomer = new Customer
        {
            Name = "John Doe",
            City = "Los Angeles"
        };
        db.GetCollection<Customer>("customers").InsertOne(newCustomer);

        // Update an existing customer
        var filter = Builders<Customer>.Filter.Eq(c => c.Name, "John Doe");
        var update = Builders<Customer>.Update.Set(c => c.City, "San Francisco");
        db.GetCollection<Customer>("customers").UpdateOne(filter, update);

        // Delete a customer
        filter = Builders<Customer>.Filter.Eq(c => c.Name, "John Doe");
        db.GetCollection<Customer>("customers").DeleteOne(filter);
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



