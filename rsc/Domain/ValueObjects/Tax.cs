using Newtonsoft.Json;

namespace Domain.ValueObjects
{
    public class Tax(double taxValue)
    {
        [JsonProperty("tax")]
        public double TaxValue { get;} = taxValue;
    }
}