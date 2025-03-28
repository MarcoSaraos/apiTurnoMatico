using System.Reflection;
using System.Runtime.Serialization;

namespace apiTurnoMatico.GenericResponses
{
    public class DBServiceResponse<T>
    {
        public T Data { get; set; }
        public string? MessageBackError { get; set; }

        public string? MessageBack { get; set; }
        // Constructor para datos
        public DBServiceResponse(T data, string _messageBack = "")
        {
            var message = _messageBack != string.Empty ? _messageBack : ObtenerMensajeEnum(DBServiceResponseGenericEnum.Success);
            Data = data;
            MessageBack = message;
        }

        // Constructor para mensajes de error
        public DBServiceResponse(string _messageBackError = "")
        {
            var message = _messageBackError != string.Empty ? _messageBackError : ObtenerMensajeEnum(DBServiceResponseGenericEnum.NotSuccess);
            MessageBackError = message;
        }

        #region [Métodos privado]
        private static string ObtenerMensajeEnum(DBServiceResponseGenericEnum enumerator)
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
        public enum DBServiceResponseGenericEnum
        {
            [EnumMember(Value = "Operación realizada correctamente en la base de datos")]
            Success,

            [EnumMember(Value = "Error al realizar la operación en la base de datos")]
            NotSuccess
        }
    }
}
