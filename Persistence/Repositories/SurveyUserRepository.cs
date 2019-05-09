using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TiburonTest.Domain.Models;
using TiburonTest.Domain.Repositories;
using TiburonTest.Persistence.Contexts;

namespace TiburonTest.Persistence.Repositories
{
    public class SurveyUserRepository : BaseRepository, ISurveyUserRepository
    {
        public SurveyUserRepository(AppDbContext context) : base(context) {}

        public async Task<IEnumerable<SurveyUser>> ListAsync()
        {
            return await _context.SurveyUsers.ToListAsync();
        }

        public async Task AddAsync(SurveyUser surveyUser)
        {
            await _context.SurveyUsers.AddAsync(surveyUser);
        }
    }
}