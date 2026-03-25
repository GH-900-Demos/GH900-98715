namespace MyAmazingConsole.Models;

/// <summary>
/// Defines the possible lifecycle stages of an <see cref="Order"/>.
/// Orders progress through these statuses from creation to closure.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// The order has been created but not yet processed.
    /// </summary>
    Created,

    /// <summary>
    /// The order has been fulfilled and completed.
    /// </summary>
    Completed,

    /// <summary>
    /// The order has been shipped to the customer.
    /// </summary>
    Shipped,

    /// <summary>
    /// The order has been closed and is no longer active.
    /// </summary>
    Closed
}
