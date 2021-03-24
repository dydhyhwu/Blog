namespace YH.Arch.Domain
{
    public class ApiResponse
    {
        public static ApiResponse Of(ResponseStatus status, string message, object data)
        {
            return new ApiResponse(status, message, data);
        }

        private ApiResponse(ResponseStatus code, string message, object data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ResponseStatus Code { get; }
        public string Message { get; }
        public object Data { get; }
    }
}
