using Common.Domain;
using System.Collections.Generic;

namespace Inventory.Domain.AggregatesModel.InventoryAggregate
{
    public class AppInventory : AggregateRoot
    {
        private readonly List<InventoryItem> _inventoryItems = new List<InventoryItem>();

        public IReadOnlyCollection<InventoryItem> Items => _inventoryItems.AsReadOnly();

        public void AddItem(InventoryItem item) => _inventoryItems.Add(item);
    }
}
