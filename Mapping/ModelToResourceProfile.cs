using AutoMapper;
using TiburonTest.Domain.Models;
using TiburonTest.Resources;
using System.Linq;
using System;

namespace TiburonTest.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<SurveyUser, SurveyUserResource>()
	        .ForMember(d => d.PhoneBrands, m => m.MapFrom(s => s.PhoneBrands.Split(", ", StringSplitOptions.None)));
        }
    }
}
