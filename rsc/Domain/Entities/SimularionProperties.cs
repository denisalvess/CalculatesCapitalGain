using Domain.ValueObjects;

namespace Domain.Entities
{
    public class SimulationProperties
    {
         public SimulationProperties()
         {
             MediumPrice = decimal.Zero;
             StockQuantity = 0;
             Balance = decimal.Zero;
             Taxes = [];
         }
        public decimal MediumPrice { get; set; }
        public int StockQuantity { get; set; }
        public decimal Balance { get; set; }
        public List<Tax> Taxes { get; set; } = [];
    }
}