using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// An in-memory implementation of <see cref="IOrderRepository"/> backed by a
/// <see cref="Dictionary{TKey, TValue}"/>. Suitable for testing, prototyping,
/// and demo scenarios where persistent storage is not required.
/// All data is lost when the application exits.
/// </summary>
public class InMemoryOrderRepository : IOrderRepository
{
    /// <summary>
    /// Internal dictionary that stores orders keyed by their <see cref="Order.Id"/>.
    /// Using a dictionary provides O(1) lookups and prevents duplicate keys.
    /// </summary>
    private readonly Dictionary<Guid, Order> _orders = [];

    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">
    /// Thrown when an order with the same <see cref="Order.Id"/> already exists in the repository.
    /// </exception>
    public void Add(Order order)
    {
        if (_orders.ContainsKey(order.Id))
            throw new InvalidOperationException($"An order with id '{order.Id}' already exists.");

        _orders[order.Id] = order;
    }

    /// <inheritdoc />
    public Order? GetById(Guid id)
    {
        _orders.TryGetValue(id, out var order);
        return order;
    }

    /// <inheritdoc />
    public IEnumerable<Order> GetAll() => _orders.Values;

    /// <inheritdoc />
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no order with the specified <see cref="Order.Id"/> exists in the repository.
    /// </exception>
    public void Update(Order order)
    {
        if (!_orders.ContainsKey(order.Id))
            throw new KeyNotFoundException($"No order found with id '{order.Id}'.");

        _orders[order.Id] = order;
    }

    /// <inheritdoc />
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no order with the specified <paramref name="id"/> exists in the repository.
    /// </exception>
    public void Delete(Guid id)
    {
        if (!_orders.Remove(id))
            throw new KeyNotFoundException($"No order found with id '{id}'.");
    }
}
