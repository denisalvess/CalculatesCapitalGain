namespace Domain.Exceptions
{
    public class ValidQuantityException : Exception
    {
        public ValidQuantityException() 
        : base("Quantidade de ações negociadas inválida, deve ser maior que zero")
         {
         }
    }
}