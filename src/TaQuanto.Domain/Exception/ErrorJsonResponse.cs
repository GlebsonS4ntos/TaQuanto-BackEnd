namespace TaQuanto.Domain.Exception;

public class ErrorJsonResponse
{
    public List<string> Errors { get; set; }

    public ErrorJsonResponse(List<string> errors) 
    { 
        Errors = errors;
    }

    public ErrorJsonResponse(string error) 
    { 
        Errors = new List<string>() { error };
    }
}
