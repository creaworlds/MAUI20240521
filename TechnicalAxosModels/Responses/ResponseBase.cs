namespace TechnicalAxosModels.Responses
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
    }
}