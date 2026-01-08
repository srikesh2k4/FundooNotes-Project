namespace ModelLayer.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
        public T? Data { get; init; }

        public static ApiResponse<T> Ok(T data, string message = "")
            => new ApiResponse<T> { Success = true, Data = data, Message = message };

        public static ApiResponse<T> Fail(string message)
            => new ApiResponse<T> { Success = false, Message = message };
    }
}
