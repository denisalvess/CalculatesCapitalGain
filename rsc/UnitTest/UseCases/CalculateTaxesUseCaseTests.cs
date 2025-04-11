using Application.UseCases;
using Domain.Exceptions;
using Domain.ValueObjects;

namespace UnitTest.UseCases
{
   [TestClass]
   public class CalculateTaxesUseCaseTests
   {
      [TestMethod]
      public void Execute_ShouldReturnTaxas_WhenOrdersAreValid()
      {
         //Arrange
         var useCase = new CalculateTaxesUseCase();
         var orders = new List<Order>
            {
               new("buy", 100.0, 10),
               new("sell", 150.0, 5)
            };

         // Act
         var taxes = useCase.Execute(orders);

         //Assert
         Assert.IsNotNull(taxes);
         Assert.AreEqual(2, taxes.Count);
      }

      [TestMethod]
      [ExpectedException(typeof(validOperationException))]
      public void Execute_ShouldThreException_WhenOrderTypeOperationIsInvalid()
      {
         // Arrange
         var orders = new Order("", 100.0, 10);

         // Act
         orders.Valid();
         
            //Assert
            // Exception is expected
       }


      [TestMethod]
      [ExpectedException(typeof(ValidunitCostException))]
      public void Execute_ShouldThrowException_WhenOrderTypeOperationIsInvalid()
      {
         // Arrange
         var orders = new Order("buy", -100, 10);

         // Act
         orders.Valid();

         // Assert
         // Exception is expected
      }

      [TestMethod]
      [ExpectedException(typeof(ValidQuantityException))]
      public void Execute_ShouldThrowException_WhenOrderQuantityIsInvalid()
      {
         // Arrange
         var orders = new Order("buy", 100.0, -10);

         // Act
         orders.Valid();

         // Assert
         // Exception is expected
      }
   }
}