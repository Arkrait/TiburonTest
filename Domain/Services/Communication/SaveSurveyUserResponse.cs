using System;
using TiburonTest.Domain.Models;

namespace TiburonTest.Domain.Services.Communication
{
    public class SaveSurveyUserResponse : BaseResponse
    {
        public SurveyUser SurveyUser { get; private set; }

        private SaveSurveyUserResponse(bool success, string message, SurveyUser surveyUser) : base(success, message)
        {
            SurveyUser = surveyUser;
        }

        /// <summary>
        /// Создает ответ с успехом
        /// </summary>
        /// <param name="surveyUser"></param>
        /// <returns>Ответ</returns>
        public SaveSurveyUserResponse(SurveyUser surveyUser) : this(true, String.Empty, surveyUser)
        {

        }

        /// <summary>
        /// Создает ответ с ошибкой
        /// </summary>
        /// <param name="message">Сообщение с ошибкой</param>
        /// <returns>Ответ</returns>
        public SaveSurveyUserResponse(string message) : this(false, message, null)
        {

        }
    }
}