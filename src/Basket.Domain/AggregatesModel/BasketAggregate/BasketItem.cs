using Common.Domain;

namespace Basket.Domain.AggregatesModel.BasketAggregate
{
    public class BasketItem : DomainEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Quantity { get; set; }
    }
}
