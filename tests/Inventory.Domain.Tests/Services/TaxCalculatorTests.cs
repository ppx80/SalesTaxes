using Inventory.Domain.AggregatesModel.InventoryAggregate;
using Inventory.Domain.Services;
using System.Linq;
using Xunit;

namespace Inventory.Domain.Tests.Services
{
    public class TaxCalculatorTests
    {
        private readonly AppInventory _inventory;
        private readonly ITaxCalculator _sut;

        public TaxCalculatorTests()
        {
            _inventory = CreateInventory();
            _sut = new TaxCalculator();
        }

        [Theory]
        [InlineData("i1", 0.00)]
        [InlineData("i2", 1.50)]
        [InlineData("i3", 0.00)]
        [InlineData("i4", 0.50)]
        [InlineData("i5", 7.15)]
        public void CalculateInventoryItemTaxes_ShouldCalculateTheExpectedTax(string itemId, double expectedTax)
        {
            var inventoryItem = _inventory.Items.SingleOrDefault(i => i.Id == itemId);
            var tax = _sut.CalculateInventoryItemTax(inventoryItem, 0.1, 0.05);
            Assert.Equal(expectedTax, tax);
        }

        private AppInventory CreateInventory()
        {
            var inventory = new AppInventory();
            inventory.AddItem(new InventoryItem
            {
                Id = "i1",
                Name = "book",
                Price = 12.49,
                IsImported = false,
                IsTaxFree = true
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i2",
                Name = "music CD",
                Price = 14.99,
                IsImported = false,
                IsTaxFree = false
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i3",
                Name = "chocolate bar",
                Price = 0.85,
                IsImported = false,
                IsTaxFree = true
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i4",
                Name = "imported box of chocolates",
                Price = 10.00,
                IsImported = true,
                IsTaxFree = true
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i5",
                Name = "imported bottle of perfume",
                Price = 47.50,
                IsImported = true,
                IsTaxFree = false
            });
            return inventory;
        }
    }
}
