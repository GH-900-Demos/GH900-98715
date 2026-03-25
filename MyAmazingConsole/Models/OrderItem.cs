namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a single line item within an <see cref="Order"/>.
/// The <see cref="Quantity"/> property enforces a positive-value constraint,
/// throwing an <see cref="ArgumentOutOfRangeException"/> for zero or negative values.
/// The <see cref="TotalCost"/> is computed as <c>Quantity × UnitCost</c>.
/// </summary>
public class OrderItem
{
    /// <summary>
    /// Gets or sets the product code that uniquely identifies the item (e.g., "PRD-001").
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a human-readable description of the item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Backing field for <see cref="Quantity"/>.
    /// </summary>
    private int _quantity;

    /// <summary>
    /// Gets or sets the number of units ordered.
    /// The setter validates that the value is greater than zero; setting it to zero
    /// or a negative number throws an <see cref="ArgumentOutOfRangeException"/>.
    /// This guard prevents invalid order data from entering the system.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is less than or equal to zero.
    /// </exception>
    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Quantity must be greater than zero.");
            _quantity = value;
        }
    }

    /// <summary>
    /// Gets or sets the cost per single unit of this item.
    /// </summary>
    public decimal UnitCost { get; set; }

    /// <summary>
    /// Gets the total cost for this line item, computed as
    /// <c><see cref="Quantity"/> × <see cref="UnitCost"/></c>.
    /// This is a computed property with no backing field.
    /// </summary>
    public decimal TotalCost => Quantity * UnitCost;
}
