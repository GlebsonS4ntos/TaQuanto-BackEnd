namespace TaQuanto.Domain.Exception
{
    public class NotFoundException : TaQuantoException
    {
        public string Error { get; set; }

        public NotFoundException(string error)
        {
            Error = error;
        }
    }
}
