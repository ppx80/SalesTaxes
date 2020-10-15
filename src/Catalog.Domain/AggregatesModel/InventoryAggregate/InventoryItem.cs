using Common.Domain;

namespace Inventory.Domain.AggregatesModel.InventoryAggregate
{
    public class InventoryItem : DomainEntity
    {
        public InventoryItem()
        {
        }

        public InventoryItem(string name, double price, bool isTaxFree, bool isImported, int quantity)
        {
            Name = name;
            Price = price;
            IsTaxFree = isTaxFree;
            IsImported = isImported;
            Quantity = quantity;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool IsTaxFree { get; set; }

        public bool IsImported { get; set; }

        public int Quantity { get; set; }
    }
}
