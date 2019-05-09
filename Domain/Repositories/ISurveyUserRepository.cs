using System.Collections.Generic;
using System.Threading.Tasks;
using TiburonTest.Domain.Models;

namespace TiburonTest.Domain.Repositories
{
    public interface ISurveyUserRepository
    {
        Task<IEnumerable<SurveyUser>> ListAsync();
        Task AddAsync(SurveyUser surveyUser);
    }
}