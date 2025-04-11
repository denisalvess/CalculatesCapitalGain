using Application.Ports;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.UseCases
{
    public class CalculateTaxesUseCase : IInputPort
    {
        private readonly IOperation _operation;
        public CalculateTaxesUseCase()
        {
            _operation = new Operation();
        }

        public List<Tax> Execute(List<Order> orders)
        {
            var SimulationProperties = new SimulationProperties();
            orders.ForEach(order =>
            {
                order.Valid();
                _operation.Execute(SimulationProperties, order);
            });

            return SimulationProperties.Taxes;
        }
    }
}