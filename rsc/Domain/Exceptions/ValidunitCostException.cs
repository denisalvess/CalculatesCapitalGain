namespace Domain.Exceptions
{
    public class ValidunitCostException : Exception
    {
        public ValidunitCostException() 
        : base("Preço unitário inválido, deve informar um valor positivo")
         {
         }
    }
}