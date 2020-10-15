using Basket.Domain.AggregatesModel.BasketAggregate;
using Inventory.Domain.AggregatesModel.InventoryAggregate;
using Inventory.Domain.Services;
using System.Collections.Generic;

namespace ReceiptPrinter
{
    /// <summary>
    /// Customer busket factory.
    /// In this app simulate a customer that selects items from the inventory and add them to the basket.
    /// </summary>
    public class CustomerBasketFactory
    {
        private readonly ITaxCalculator _taxCalculator;
        public CustomerBasketFactory(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        /// <summary>
        /// Create a customer busket starting from selected iventory item.
        /// </summary>
        /// <param name="customerId">/The customer ID.</param>
        /// <param name="items">Inventory items list.</param>
        /// <returns>New customer basket.</returns>
        public CustomerBasket CreateCustomerBasket(string customerId, IEnumerable<InventoryItem> items)
        {
            var basket = new CustomerBasket(customerId);
            foreach(var item in items)
            {
                BasketItem basketItem = new BasketItem
                {
                    Price = item.Price,
                    ProductName = item.Name,
                    Quantity = 1,
                    Tax = _taxCalculator.CalculateInventoryItemTax(item, 0.1, 0.05)
                };
                basket.AddItem(basketItem);
            }

            return basket;
        }
    }
}
