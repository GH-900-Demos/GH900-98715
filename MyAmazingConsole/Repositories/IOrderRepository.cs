using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// Defines the contract for persisting and retrieving <see cref="Order"/> entities.
/// Implementations provide CRUD (Create, Read, Update, Delete) operations
/// against a backing store.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Adds a new order to the repository.
    /// </summary>
    /// <param name="order">The <see cref="Order"/> to add.</param>
    void Add(Order order);

    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="id">The <see cref="Guid"/> of the order to find.</param>
    /// <returns>
    /// The matching <see cref="Order"/> if found; otherwise, <see langword="null"/>.
    /// </returns>
    Order? GetById(Guid id);

    /// <summary>
    /// Retrieves all orders currently stored in the repository.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of all <see cref="Order"/> entities.</returns>
    IEnumerable<Order> GetAll();

    /// <summary>
    /// Updates an existing order in the repository.
    /// </summary>
    /// <param name="order">The <see cref="Order"/> with updated data. Its <see cref="Order.Id"/> must match an existing entry.</param>
    void Update(Order order);

    /// <summary>
    /// Removes an order from the repository by its unique identifier.
    /// </summary>
    /// <param name="id">The <see cref="Guid"/> of the order to remove.</param>
    void Delete(Guid id);
}
