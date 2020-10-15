using Basket.Domain.AggregatesModel.BasketAggregate;
using Basket.Domain.Services;
using System.Text;
using Xunit;

namespace Basket.Domain.Tests.Services
{
    public class ReceiptServiceTests
    {
        private readonly IReceiptService _sut;

        public ReceiptServiceTests()
        {
            _sut = new ReceiptService();
        }

        [Fact]
        public void CreateReceipt_ValidBasket_ShouldReturnsTheExpectedContent()
        {
            var expectedReceiptContent = CreateExpectedReceiptContent();
            
            var basket = new CustomerBasket();
            basket.AddItem(new BasketItem
            {
                Id = "b1", Price = 10.00, ProductName = "Test Product 1", Quantity = 2, Tax = 0.15
            });
            basket.AddItem(new BasketItem
            {
                Id = "b2", Price = 5.00, ProductName = "Test Product 2", Quantity = 1, Tax = 0.10
            });
            var receiptContent = _sut.CreateReceipt(basket);
            Assert.Equal(expectedReceiptContent, receiptContent);
        }

        private static string CreateExpectedReceiptContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("2 Test Product 1: 20.30");
            stringBuilder.AppendLine("1 Test Product 2: 5.10");
            stringBuilder.AppendLine("Sales Taxes: 0.40");
            stringBuilder.AppendLine("Total: 25.40");

            return stringBuilder.ToString();
        }
    }
}
