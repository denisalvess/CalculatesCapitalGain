namespace Domain.Exceptions
{
    public  class validOperationException : Exception
    {
        public validOperationException() 
        : base("Operação de compra invalido, deve informar BY ou SELL")
         {
         }
    }
}