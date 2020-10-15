using Inventory.Domain.AggregatesModel.InventoryAggregate;
using System;

namespace Inventory.Domain.Services
{
    /// <summary>
    /// Inventory item tax calulator
    /// </summary>
    public class TaxCalculator : ITaxCalculator
    {
        /// <summary>
        /// Calculate the tax for the item.
        /// </summary>
        /// <param name="item">The inventory item.</param>
        /// <param name="taxRate">The tax rate applied to all good except those that are tax-free</param>
        /// <param name="additionalRateForImportedItem">/The additional tax rate for imported item.</param>
        /// <returns>The sales tax applicable to the item.</returns>
        public double CalculateInventoryItemTax(InventoryItem item, double taxRate, double additionalRateForImportedItem)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            if (taxRate <= 0)
            {
                throw new ArgumentException($"The {nameof(taxRate)} must be greater than 0");
            }
            if (additionalRateForImportedItem <= 0)
            {
                throw new ArgumentException($"The {nameof(additionalRateForImportedItem)} must be greater than 0");
            }

            double totlalRate = 0.00;
            if(item.IsImported)
            {
                totlalRate += additionalRateForImportedItem;
            }

            if(!item.IsTaxFree)
            {
                totlalRate += taxRate;
            }

            var totalTaxes = item.Price * totlalRate;
            //return Math.Round(totalTaxes * 20) / 20;
            return Math.Ceiling(totalTaxes * 20) / 20;
        }
    }
}
