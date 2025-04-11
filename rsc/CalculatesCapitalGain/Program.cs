// CLI/Program.cs
using Application.Ports;
using Application.UseCases;
using Domain.ValueObjects;
using Newtonsoft.Json;

IInputPort inputPort = new CalculateTaxesUseCase();

Console.WriteLine(" ..:: To calculate capital gain ::..");
Console.WriteLine("");

List<List<Order>> _orders = [];
string? input = string.Empty;

if (args.Length > 0)
   input = args[0];
else
  input = Console.ReadLine();


if (!string.IsNullOrEmpty(input))
{
    if (File.Exists(input))
       input = File.ReadAllText(input);
    else
      input = input.Replace("\r", "").Replace("\n","").Replace("\t","");

    string[] lines = input.Split(["\r\n","\n"],StringSplitOptions.None);
    foreach(var line in lines)
    {
        var orders = JsonConvert.DeserializeObject<List<Order>>(line); 
        if (orders != null)
            _orders.Add(orders);    
    }
     
    if (_orders.Count > 0)
        _orders.ForEach(o => Console.WriteLine(JsonConvert.SerializeObject(inputPort.Execute(o))));
}