namespace wms.ErrorHandling;

public class MultiErrorResponse
{
    public ErrorOr.Error FirstError { get; set; }
    public IEnumerable<string> Errors { get; set; }
}