using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjects;

namespace ACME.OOP.Procurement.Domain.Model.Aggregates;

public class PurchaseOrder(string orderNumber, SupplierId supplierId,
    DateTime orderDate, string currency)
{
    public string OrderNumber { get; } = orderNumber?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) || currency.Length!=3 ?
        throw new ArgumentNullException(nameof(currency)): currency;
        
    
    private readonly List<PurchaseOrderItem> _items = new();
    public IReadOnlyCollection<PurchaseOrderItem> Items => _items.AsReadOnly();

    public void AddItem(PurchaseOrderItem item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        if (item.UnitPrice.Currency != Currency)
            throw new InvalidOperationException("Item currency must match order currency.");
        _items.Add(item);
    }

    public Money CalculateTotalAmount()
    {
        var total = _items.Sum(i => i.CalculateItemTotal().Amount);
        return new Money(total, Currency);
    }   
}