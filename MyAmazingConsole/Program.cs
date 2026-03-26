using MyAmazingConsole.Models;
using MyAmazingConsole.Repositories;

IOrderRepository repository = new InMemoryOrderRepository();

// Create first order
var order1 = new Order
{
    Customer = new Customer
    {
        FirstName = "Alice",
        LastName = "Smith",
        Address = "123 Main St, Springfield"
    },
    Items =
    [
        new OrderItem { Code = "PRD-001", Description = "Wireless Mouse", Quantity = 2, UnitCost = 29.99m },
        new OrderItem { Code = "PRD-002", Description = "USB-C Hub",      Quantity = 1, UnitCost = 49.99m }
    ]
};

// Create second order
var order2 = new Order
{
    Customer = new Customer
    {
        FirstName = "Bob",
        LastName = "Jones",
        Address = "456 Oak Ave, Shelbyville"
    },
    Items =
    [
        new OrderItem { Code = "PRD-003", Description = "Mechanical Keyboard", Quantity = 1, UnitCost = 119.99m }
    ]
};

repository.Add(order1);
repository.Add(order2);

// Update order2 status
order2.Status = OrderStatus.Shipped;
repository.Update(order2);

// Display all orders
Console.WriteLine("=== All Orders ===");
foreach (var order in repository.GetAll())
{
    Console.WriteLine($"\nOrder ID : {order.Id}");
    Console.WriteLine($"Customer : {order.Customer.FirstName} {order.Customer.LastName}");
    Console.WriteLine($"Address  : {order.Customer.Address}");
    Console.WriteLine($"Status   : {order.Status}");
    Console.WriteLine($"Created  : {order.CreatedAt:u}");
    Console.WriteLine("Items:");
    foreach (var item in order.Items)
        Console.WriteLine($"  [{item.Code}] {item.Description} — qty: {item.Quantity} x {item.UnitCost:C} = {item.TotalCost:C}");
    Console.WriteLine($"Total    : {order.TotalCost:C}");
}

// Retrieve a single order by ID
Console.WriteLine($"\n=== Lookup order {order1.Id} ===");
var found = repository.GetById(order1.Id);
Console.WriteLine(found is not null ? $"Found: {found.Customer.LastName}, {found.Customer.FirstName}" : "Not found.");

// Delete an order
repository.Delete(order2.Id);
Console.WriteLine($"\nAfter deletion — total orders: {repository.GetAll().Count()}");

