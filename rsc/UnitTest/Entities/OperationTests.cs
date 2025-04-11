using Domain.Constants;
using Domain.Entities;
using Domain.ValueObjects;

namespace UnitTest.Entities
{
    [TestClass]
    public class OperationTests
    {
        [TestMethod]
        public void Execute_ShouldUpdateSimulationProperties_whanBuyOperation()
        {
            // Arrange
            var operation = new Operation();
            var simulationProperties = new SimulationProperties
                {
                    MediumPrice = 100.0m,
                    StockQuantity = 10,
                    Taxes = []
                };
            var order = new Order(ConstOperation.OPERATION_BUY, 150.0, 5);

            // Act
            operation.Execute(simulationProperties, order);

            // Assert
            Assert.AreEqual(15, simulationProperties.StockQuantity);
            Assert.AreEqual(116.67M, simulationProperties.MediumPrice);
            Assert.AreEqual(1, simulationProperties.Taxes.Count);
            Assert.AreEqual(0.00, simulationProperties.Taxes[0].TaxValue);

        }

        [TestMethod]
        public void Execute_ShouldUpdateSimulationProperties_whenSellOperation()
        {
            //Arrange
            var operation = new Operation();
            var simulationProperties = new SimulationProperties
                {
                    MediumPrice = 100.0m,
                    StockQuantity = 10,
                    Balance = 0.0m,
                    Taxes = []
                };
            var order = new Order(ConstOperation.OPERATION_SELL, 156.0, 5);

            // Act
            operation.Execute(simulationProperties, order);

            //Assert
            Assert.AreEqual("sell", order.TypeOperation);
            Assert.AreEqual(156.0, order.UnitCost);
            Assert.AreEqual(5, order.Quantity);
            Assert.AreEqual(5, simulationProperties.StockQuantity);
            Assert.AreEqual(280.00m, simulationProperties.Balance);
            Assert.AreEqual(1, simulationProperties.Taxes.Count);
            Assert.AreEqual(0, simulationProperties.Taxes[0].TaxValue);
        }
    }
}