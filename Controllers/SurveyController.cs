using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TiburonTest.Domain.Models;
using TiburonTest.Domain.Services;
using TiburonTest.Resources;

namespace TiburonTest.Controllers
{
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly ISurveyUserService _surveyUserService;
        private readonly IMapper _mapper;

        public SurveyController(ISurveyUserService surveyUserService, IMapper mapper)
        {
            _surveyUserService = surveyUserService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SurveyUserResource>> ListAsync()
        {
            var surveyUsers = await _surveyUserService.ListAsync();
	    var resources = _mapper.Map<IEnumerable<SurveyUser>, IEnumerable<SurveyUserResource>>(surveyUsers);

	    return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSurveyUserResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState
                    .SelectMany(m => m.Value.Errors)
                    .Select(m => m.ErrorMessage)
                    .ToList());
            }

            var surveyUser = _mapper.Map<SaveSurveyUserResource, SurveyUser>(resource);
            var result = await _surveyUserService.SaveAsync(surveyUser);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.SurveyUser);
        }
    }
}
