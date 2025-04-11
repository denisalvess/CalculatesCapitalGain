using Domain.Constants;
using Domain.ValueObjects;


namespace Domain.Entities
{
    public class Operation : IOperation
    {
        public void Execute(SimulationProperties parameters, Order order)
        {
            if (order.TypeOperation.Equals(ConstOperation.OPERATION_BUY, StringComparison.CurrentCultureIgnoreCase))
            {
                var currentPrice = parameters.MediumPrice * parameters.StockQuantity;
                var newPrice = (decimal)(order.UnitCost * order.Quantity);

                parameters.StockQuantity += order.Quantity;
                var quantity = parameters.StockQuantity;
                var result = currentPrice + newPrice;

                if (parameters.StockQuantity > 0)
                {
                    result = Math.Round(result / quantity, 2, MidpointRounding.AwayFromZero);
                }

                parameters.MediumPrice = result;
                parameters.Taxes.Add(new Tax(0.00));
            }
            else
            {
                var total = order.Quantity * order.UnitCost;
                var previousTotal = parameters.MediumPrice * order.Quantity;
                parameters.Balance += (decimal)(total - (double)previousTotal);

                Tax tax = new(0.00);
                if (total > ConstOperation.TaxLimited || parameters.Balance > ConstOperation.TaxLimited)
                {
                    var totalTax = Math.Round((double)parameters.Balance * 0.20, 2, MidpointRounding.AwayFromZero);
                    if (totalTax > 0)
                    {
                        tax = new Tax(totalTax);
                        parameters.Balance = 0;
                    }
                }

                parameters.Taxes.Add(tax);
                parameters.StockQuantity -= order.Quantity;
            }
        }
    }
}