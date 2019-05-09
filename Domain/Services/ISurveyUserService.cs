using System.Collections.Generic;
using System.Threading.Tasks;
using TiburonTest.Domain.Models;
using TiburonTest.Domain.Services.Communication;

namespace TiburonTest.Domain.Services
{
    public interface ISurveyUserService
    {
        Task<IEnumerable<SurveyUser>> ListAsync();
        Task<SaveSurveyUserResponse> SaveAsync(SurveyUser surveyUser);
    }
}