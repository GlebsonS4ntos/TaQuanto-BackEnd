namespace TaQuanto.Domain.Exception
{
    public class HeaderIdException : TaQuantoException
    {
        public string Error { get; set; }

        public HeaderIdException(string error)
        {
            Error = error;
        }
    }
}
