using Domain.Constants;
using Domain.Entities;
using Domain.Exceptions;
using Newtonsoft.Json;

namespace Domain.ValueObjects
{
   public class Order(string typeEnum, double unitCost, int quantity) : IBaseEntity
   {
      [JsonProperty("operation")]
      public string TypeOperation { get; private set; } = typeEnum;

      [JsonProperty("unit-cost")]
      public double UnitCost { get; protected set; } = unitCost;

      [JsonProperty("quantity")]
      public int Quantity { get; protected set; } = quantity;
      private readonly List<string> ValidOperation = [ConstOperation.OPERATION_BUY, ConstOperation.OPERATION_SELL];

      public void Valid()
      {
         if (!ValidOperation.Contains(TypeOperation))
            throw new validOperationException();

         if (!double.IsPositive(UnitCost))
            throw new ValidunitCostException();

         if (!int.IsPositive(Quantity))
            throw new ValidQuantityException();

      }
   } 
}

