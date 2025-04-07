using System.Runtime.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace apiTurnoMatico.Tools
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode {get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public string[]? Errors { get; set; }

        /// <summary>
        /// Success return
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <param name="message"></param>
        public ApiResponse(int statusCode, T data, string message = "")
        {
            Success = true;
            StatusCode = statusCode;
            Data = data;
            Message = message;
            Errors = null;
        }

        /// <summary>
        /// Error return 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiResponse(int statusCode, string message = "", string[] errors = null)
        {
            Success = false;
            StatusCode = statusCode;
            Message = message;
            Errors = errors;
        }




    }
}
