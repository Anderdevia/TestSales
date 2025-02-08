using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.Domain.Shared
{
        using System.Text.Json.Serialization;

        /// <summary>
        /// Defines the <see cref="BaseResponse{T}" />
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class BaseResponse<T>
        {
        public bool Success;

        /// <summary>
        /// Gets or sets a value indicating whether IsSuccessful
        /// Valor que indica si la operación fue exitosa.
        /// </summary>
        public bool IsSuccessful { get; set; }

            /// <summary>
            /// Gets or sets the ResponseCode
            /// Código de respuesta asociado con la operación.
            /// </summary>
            public int ResponseCode { get; set; }

            /// <summary>
            /// Gets or sets the Message
            /// Mensaje de error asociado con la respuesta. 
            /// Puede ser nulo si no hay mensaje que mostrar.
            /// </summary>
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? Message { get; set; }

            /// <summary>
            /// Gets the ResponseDate
            /// Fecha y hora UTC en la que se generó la respuesta.
            /// </summary>
            public DateTime ResponseDate { get; } = DateTime.Now;

            /// <summary>
            /// Gets or sets the Data
            /// Datos asociados con la respuesta. 
            /// Puede ser nulo si no hay datos que retornar.
            /// </summary>
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public T? Data { get; set; }
        }

        /// <summary>
        /// Defines the <see cref="BaseResponse" />
        /// </summary>
        public class BaseResponse
        {
            /// <summary>
            /// Gets a value indicating whether IsSuccessful
            /// </summary>
            public bool IsSuccessful { get => string.IsNullOrEmpty(ErrorMessage); }

            /// <summary>
            /// Gets or sets the ResponseCode
            /// </summary>
            public int ResponseCode { get; set; }

            /// <summary>
            /// Gets or sets the ErrorMessage
            /// </summary>
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? ErrorMessage { get; set; }

            /// <summary>
            /// Gets the ResponseDate
            /// </summary>
            public DateTime ResponseDate { get; } = DateTime.Now;

            /// <summary>
            /// Gets or sets the Data
            /// </summary>
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public object? Data { get; set; }
        }

        public class DatabaseTransactionResponse
        {
            public string? ResponseMessage { get; set; }
            public bool IsSuccessful { get; set; } = false;
        }
}
