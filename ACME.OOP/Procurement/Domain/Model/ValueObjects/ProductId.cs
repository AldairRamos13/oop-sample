namespace ACME.OOP.Procurement.Domain.Model.ValueObjects;

public record ProductId
{
    public Guid Id { get; init; }
    /// <summary>
    /// Creates a new instance of ProductId
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="ArgumentException">Thrown when the provided GUID is empty</exception>
    
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("ProductId cannot be empty.", nameof(id));

        Id = id;
    }
    
    public static ProductId New() => new (Guid.NewGuid());
    public override string ToString() => Id.ToString();
}