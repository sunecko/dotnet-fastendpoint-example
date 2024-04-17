namespace Example.Application.Common.ResponseModels;

public class ResponseError
{
    public string LongMessage { get; set; } = string.Empty;
    public string ShortMessage { get; set; } = string.Empty;
    public int HttpStatus { get; set; }
}