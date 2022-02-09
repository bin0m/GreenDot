using AutoMapper;
using GreenDot.API.Helpers;

namespace GreenDot.API.MapperProfiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            CreateMap<Entities.Author, Models.AuthorDto>()
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Models.AuthorForCreationDto, Entities.Author>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Courses,
                    opt => opt.Ignore());
        }
    }
}