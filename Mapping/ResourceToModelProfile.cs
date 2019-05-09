using AutoMapper;
using TiburonTest.Domain.Models;
using TiburonTest.Resources;

namespace TiburonTest.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveSurveyUserResource, SurveyUser>()
	        .ForMember(dest => dest.PhoneBrands, m => m.MapFrom(src => string.Join(", ", src.PhoneBrands)));
        }
    }
}
