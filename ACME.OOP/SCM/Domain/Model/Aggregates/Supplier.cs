using ACME.OOP.Shared.Domain.Model.ValueObjects;
namespace ACME.OOP.SCM.Domain.Model.Aggregates;
/// <summary>
/// Represents a supplier aggregate in the Supply Chain Management bounded context.
/// </summary>
/// <param name="identifier">The unique identifier for the supplier</param>
/// <param name="name">The name of the supplier</param>
/// <param name="address">The<see cref="Address"/></param>
public class Supplier(string identifier, string name, Address address)
{
    public string Identifier { get; } = identifier?? throw new ArgumentNullException(nameof(identifier));
    public string Name { get;} = name;
    public Address Address { get;} = address;
}