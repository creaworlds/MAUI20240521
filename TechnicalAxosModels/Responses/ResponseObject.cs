namespace TechnicalAxosModels.Responses
{
    public class ResponseObject<T> : ResponseBase
    {
        public T Result { get; set; }
    }
}