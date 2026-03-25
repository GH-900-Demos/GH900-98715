namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a customer who can place orders.
/// Holds the customer's personal and shipping information.
/// </summary>
public class Customer
{
    /// <summary>
    /// Gets or sets the customer's first name.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer's last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer's shipping address.
    /// </summary>
    public string Address { get; set; } = string.Empty;
}
