using Domain.ValueObjects;

namespace Application.Ports
{
    public interface IInputPort
    {
        List<Tax> Execute(List<Order> orders);
    }
}