using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Date_Prediction.Domain.Shared
{
        /// <summary>
        /// Defines the <see cref="Response" />
        /// </summary>
        public class Response
        {
            /// <summary>
            /// The SuccessResponse
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="data">The data<see cref="T"/></param>
            /// <param name="isSuccessful">The isSuccessful<see cref="bool"/></param>
            /// <param name="responseCode">The responseCode<see cref="int"/></param>
            /// <param name="message">The message<see cref="string"/></param>
            /// <returns>The <see cref="BaseResponse{T}"/></returns>
            public static BaseResponse<T> SuccessResponse<T>(T data, bool isSuccessful, int responseCode, string message) =>
                new()
                {
                    Data = data,
                    IsSuccessful = isSuccessful,
                    ResponseCode = responseCode,
                    Message = message
                };

            /// <summary>
            /// The ErrorResponse
            /// </summary>
            /// <param name="statusCodes">The statusCodes<see cref="int"/></param>
            /// <param name="message">The message<see cref="string"/></param>
            /// <returns>The <see cref="BaseResponse"/></returns>
            public static BaseResponse ErrorResponse(int statusCodes, string message) =>
                new()
                {
                    ResponseCode = statusCodes,
                    ErrorMessage = message,
                };

            /// <summary>
            /// The CustomResponse
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="statusCodes">The statusCodes<see cref="int"/></param>
            /// <param name="message">The message<see cref="string"/></param>
            /// <returns>The <see cref="BaseResponse{T}"/></returns>
            public static BaseResponse<T> CustomResponse<T>(int statusCodes, string message) =>
                new()
                {
                    ResponseCode = statusCodes,
                    Message = message
                };

            /// <summary>
            /// The CustomResponse
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="data">The data<see cref="T"/></param>
            /// <param name="statusCodes">The statusCodes<see cref="int"/></param>
            /// <param name="message">The message<see cref="string"/></param>
            /// <returns>The <see cref="BaseResponse{T}"/></returns>
            public static BaseResponse<T> CustomResponse<T>(T data, int statusCodes, string message) =>
                new()
                {
                    Data = data,
                    ResponseCode = statusCodes,
                    Message = message
                };
        }
}
