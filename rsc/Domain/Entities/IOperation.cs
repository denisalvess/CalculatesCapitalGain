using Domain.ValueObjects;

namespace Domain.Entities
{
  public interface IOperation
  {
    void Execute(SimulationProperties simulationProperties, Order order);
  }
}
