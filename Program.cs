using System;

Console.WriteLine("Opening customer dashboard...");

var dashboard = new CustomerDashboard();
dashboard.LoadCustomerSummary(42);

public class CustomerDashboard
{
    private readonly CustomerRepository _repository = new();
    private readonly CustomerSummaryBuilder _summaryBuilder = new();

    public void LoadCustomerSummary(int customerId)
    {
        Console.WriteLine("Loading account details...");

        var customer = _repository.GetCustomer(customerId);
        var summary = _summaryBuilder.Build(customer);

        Console.WriteLine(summary);
    }
}

public class CustomerRepository
{
    public Customer? GetCustomer(int customerId)
    {
        if (customerId == 42)
        {
            // Simulates a failed lookup or a missing object initialization.
            return null;
        }

        return new Customer
        {
            Id = customerId,
            FullName = "Ada Johnson",
            Address = new Address
            {
                Street = "15 Main Street",
                City = "Seattle"
            }
        };
    }
}

public class CustomerSummaryBuilder
{
    public string Build(Customer customer)
    {
        var city = customer.Address.City;
        var greeting = $"{customer.FullName} is located in {city}.";

        return greeting;
    }
}

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public Address? Address { get; set; }
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}
