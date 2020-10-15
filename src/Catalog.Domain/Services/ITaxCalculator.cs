namespace Inventory.Domain.Services
{
    public interface ITaxCalculator
    {
        double CalculateInventoryItemTax(
            AggregatesModel.InventoryAggregate.InventoryItem item,
            double taxRate,
            double additionalRateForImportedItem);
    }
}
