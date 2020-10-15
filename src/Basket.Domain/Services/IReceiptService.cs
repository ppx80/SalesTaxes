using Basket.Domain.AggregatesModel.BasketAggregate;

namespace Basket.Domain.Services
{
    public interface IReceiptService
    {
        string CreateReceipt(CustomerBasket basket);
    }
}
