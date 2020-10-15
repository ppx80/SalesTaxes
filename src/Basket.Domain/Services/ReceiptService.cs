using Basket.Domain.AggregatesModel.BasketAggregate;
using System.Text;
using System;
using System.Globalization;

namespace Basket.Domain.Services
{
    /// <summary>
    /// The receipt service
    /// </summary>
    public class ReceiptService : IReceiptService
    {
        /// <summary>
        /// Create the receipt content startig from the customer basket.
        /// </summary>
        /// <param name="basket">/The customer basket.</param>
        /// <returns>The content of the receipt.</returns>
        public string CreateReceipt(CustomerBasket basket)
        {
            if (basket == null || basket.Items.Count ==0)
            {
                throw new ArgumentNullException(nameof(basket));
            }

            double total = 0.00;
            double salesTaxes = 0.00;
            var stringBuilder = new StringBuilder();
            foreach(var item in basket.Items)
            {
                salesTaxes += item.Tax * item.Quantity;
                var totalPrice = (item.Price + item.Tax) * item.Quantity;
                total += totalPrice;
                stringBuilder.AppendLine($"{item.Quantity} {item.ProductName}: {totalPrice:F2}");
            }
            var totalAmount = Convert.ToDecimal(total);

            stringBuilder.AppendLine($"Sales Taxes: {salesTaxes:F2}");
            stringBuilder.AppendLine($"Total: {totalAmount:F2}");

            return stringBuilder.ToString();
        }
    }
}
