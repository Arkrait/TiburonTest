using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiburonTest.Domain.Models;
using TiburonTest.Domain.Repositories;
using TiburonTest.Domain.Services;
using TiburonTest.Domain.Services.Communication;

namespace TiburonTest.Services
{
    public class SurveyUserService : ISurveyUserService
    {
        private readonly ISurveyUserRepository _surveyUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SurveyUserService(ISurveyUserRepository surveyUserRepository, IUnitOfWork unitOfWork)
        {
            _surveyUserRepository = surveyUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SurveyUser>> ListAsync()
        {
            return await _surveyUserRepository.ListAsync();
        }

        public async Task<SaveSurveyUserResponse> SaveAsync(SurveyUser surveyUser)
        {
            try
            {
                await _surveyUserRepository.AddAsync(surveyUser);
                await _unitOfWork.CompleteAsync();

                return new SaveSurveyUserResponse(surveyUser);
            }
            catch (Exception e)
            {
                return new SaveSurveyUserResponse($"Произошла ошибка: {e.Message}");
            }
        }
    }
}