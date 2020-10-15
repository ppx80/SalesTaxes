using Common.Domain;
using System.Collections.Generic;

namespace Basket.Domain.AggregatesModel.BasketAggregate
{
    public class CustomerBasket : AggregateRoot
    {
        private readonly List<BasketItem> _basketItems = new List<BasketItem>();
        public string CustomerId { get; private set; } = "42";

        public CustomerBasket()
        {
        }

        public CustomerBasket(string customerId)
        {
            CustomerId = customerId;
        }

        public IReadOnlyCollection<BasketItem> Items => _basketItems.AsReadOnly();

        public void AddItem(BasketItem item) => _basketItems.Add(item);
    }
}
