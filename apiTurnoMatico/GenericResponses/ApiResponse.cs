using System.Reflection;
using System.Runtime.Serialization;

namespace apiTurnoMatico.GenericResponses
{

    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        // Constructor para éxito
        public ApiResponse(int statusCode, T data, string message)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }

        // Constructor para error
        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        // Método de éxito
        public static ApiResponse<T> Success(T data, string anotherMessage = "")
        {
            var message = anotherMessage != string.Empty ? anotherMessage : ObtenerMensajeEnum(ApiResponseGenericEnum.Success);
            return new ApiResponse<T>(200, data, message);
        }

        // Método de error
        public static ApiResponse<T> Error(string anotherMessage = "")
        {
            var message = anotherMessage != string.Empty ? anotherMessage : ObtenerMensajeEnum(ApiResponseGenericEnum.NotFound);
            return new ApiResponse<T>(400, message);
        }

        // Método de error
        public static ApiResponse<T> Error(string anotherMessage = "", dynamic data = null)
        {
            var message = anotherMessage != string.Empty ? anotherMessage : ObtenerMensajeEnum(ApiResponseGenericEnum.NotFound);
            return new ApiResponse<T>(400, data, message);
        }

        public static ApiResponse<T> NoAuthorizado(string anotherMessage = "")
        {
            var message = anotherMessage != string.Empty ? anotherMessage : ObtenerMensajeEnum(ApiResponseGenericEnum.Unauthorized);
            return new ApiResponse<T>(401, message);
        }
        #region [Métodos privado]
        private static string ObtenerMensajeEnum(ApiResponseGenericEnum enumerator)
        {
            // Obtener el tipo del enum
            var enumType = enumerator.GetType();

            string message = string.Empty;

            // Obtener el miembro específico del enum
            var memberInfo = enumType.GetMember(enumerator.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                // Obtener el atributo EnumMember si existe
                var attribute = memberInfo.GetCustomAttribute<EnumMemberAttribute>();

                if (attribute != null)
                {
                    return attribute.Value;
                }
            }

            // Retornar el nombre del enum si no se encuentra el atributo EnumMember
            return enumerator.ToString();
        }
        #endregion

        [DataContract]
        public enum ApiResponseGenericEnum
        {
            [EnumMember(Value = "Hmm... parece que nos encontramos con algo inesperado. ¡Pero no te preocupes, todo saldrá bien! 😊")]
            Default,

            [EnumMember(Value = "Operación realizada correctamente")]
            Success,

            [EnumMember(Value = "Error al realizar la operación")]
            NotFound,

            [EnumMember(Value = "Error interno")]
            InternalError,

            [EnumMember(Value = "No autorizado. Verifique su autenticación.")]
            Unauthorized,

            [EnumMember(Value = "Hmm... parece que nos encontramos con que no tiene permisos pillín, Acceso denegado")]
            Forbidden,

            [EnumMember(Value = "Tu sesión ha finalizado. Por favor, inicia sesión nuevamente.")]
            FinishSession

        }
    }
}
