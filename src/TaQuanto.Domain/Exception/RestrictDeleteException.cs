namespace TaQuanto.Domain.Exception
{
    public class RestrictDeleteException : TaQuantoException
    {
        public string Error { get; set; }

        public RestrictDeleteException(string error)
        {
            Error = error;
        }
    }
}
