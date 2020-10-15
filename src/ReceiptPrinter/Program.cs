using Basket.Domain.AggregatesModel.BasketAggregate;
using Basket.Domain.Services;
using Inventory.Domain.AggregatesModel.InventoryAggregate;
using Inventory.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReceiptPrinter
{
    class Program
    {
        static void Main()
        {
            List<string> selectedInventoryItems = null;
            Console.WriteLine("Which receipt do you want to print? [1,2,3]");
            var inventoryItems = Console.ReadLine();
            switch(inventoryItems)
            {
                case "1":
                    selectedInventoryItems = new List<string> { "i1", "i2", "i3" };
                    break;
                case "2":
                    selectedInventoryItems = new List<string> { "i4", "i5" };
                    break;
                case "3":
                    selectedInventoryItems = new List<string> { "i6", "i7", "i8", "i9" };
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    return;
            }

            Console.WriteLine("Receipt");
            AppInventory inventory = CreateInventory();
            CustomerBasket basket = new CustomerBasketFactory(new TaxCalculator())
                .CreateCustomerBasket(
                    "customer1",
                    inventory.Items.Where(i => selectedInventoryItems.Contains(i.Id)).ToList());

            var receipt = new ReceiptService().CreateReceipt(basket);
            Console.WriteLine(receipt);
            Console.ReadLine();
        }

        private static AppInventory CreateInventory()
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
            inventory.AddItem(new InventoryItem
            {
                Id = "i6",
                Name = "imported bottle of perfume",
                Price = 27.99,
                IsImported = true,
                IsTaxFree = false
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i7",
                Name = "bottle of perfume",
                Price = 18.99,
                IsImported = false,
                IsTaxFree = false
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i8",
                Name = "packet of headache pills",
                Price = 9.75,
                IsImported = false,
                IsTaxFree = true
            });
            inventory.AddItem(new InventoryItem
            {
                Id = "i9",
                Name = "box of imported chocolates",
                Price = 11.25,
                IsImported = true,
                IsTaxFree = true
            });
            return inventory;
        }
    }
}
