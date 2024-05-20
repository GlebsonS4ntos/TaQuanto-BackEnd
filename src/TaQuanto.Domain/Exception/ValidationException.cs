namespace TaQuanto.Domain.Exception
{
    public class ValidationException : TaQuantoException
    {
        public List<string> Errors { get; set; }

        public ValidationException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
