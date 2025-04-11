using Application.UseCases;
using Domain.Constants;
using Domain.Exceptions;
using Domain.ValueObjects;
using Newtonsoft.Json;

namespace UnitTest.CalculatesCapitalGain
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_ShoudCalculateTaxesFromValidInput()
        {
            //Arrange
            var _useCase = new CalculateTaxesUseCase();
            var taxes = new List<Tax>();
            var orders = new List<Order>
                {
                    new (ConstOperation.OPERATION_BUY,40,2),
                    new (ConstOperation.OPERATION_SELL,410,50),
                };
            var inputJson = JsonConvert.SerializeObject(orders);
            File.WriteAllText("testInput.json", inputJson);


            // Act
            var input = File.ReadAllText("testInput.json");
            var deserializedOrders = JsonConvert.DeserializeObject<List<Order>>(input);
            if (deserializedOrders != null)
                taxes = _useCase.Execute(deserializedOrders);


            // Assert
            Assert.AreEqual(2, taxes.Count);
            Assert.AreEqual(0, taxes[0].TaxValue);
            Assert.AreEqual(3700, taxes[1].TaxValue);

            // Cleanup
            File.Delete("testInput.json");

        }

        [TestMethod]
        public void Program_ShouldHandleEmptyInput()
        {
            // Arrange
            var inputPort = new CalculateTaxesUseCase();
            var input = "[]";
            var deserializedOrders = JsonConvert.DeserializeObject<List<Order>>(input);
            var taxes = new List<Tax>();

            // Act
            if (deserializedOrders != null)
                taxes = inputPort.Execute(deserializedOrders);


            // Assert
            Assert.IsNotNull(taxes);
            Assert.AreEqual(0, taxes.Count);
        }

        [TestMethod]
        public void Program_ShouldThrowExceptionFor_InvalidInput()
        {
            // Arrange
            var orders = new List<Order>
            {
            new (ConstOperation.OPERATION_SELL, -100, 2)
            };

            var inputJson = JsonConvert.SerializeObject(orders);
            File.WriteAllText("testInput.json", inputJson);

            // Act & Assert
            var inputPort = new CalculateTaxesUseCase();
            var input = File.ReadAllText("testInput.json");
            var deserializedorders = JsonConvert.DeserializeObject<List<Order>>(input);
            if (deserializedorders != null)
                Assert.ThrowsException<ValidunitCostException>(() => inputPort.Execute(deserializedorders));
            // Cleanup
            File.Delete("testInput.json");
        }
    }
}