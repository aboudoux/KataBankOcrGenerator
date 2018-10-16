namespace KataBankOcrGenerator.Exceptions
{
    public class ArgumentParserException : AccountNumberException
    {
        public ArgumentParserException(string message)  : base(message)
        {
            
        }
    }
}