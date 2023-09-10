using AutoMapper;

namespace SurveyFormProject.Profiles
{
    public class GuestResponseProfile : Profile
    {
        public GuestResponseProfile()
        {
            CreateMap<Entities.GuestResponse, Models.GuestResponseDto>().ReverseMap();     
        }
    }
}
