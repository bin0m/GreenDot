using AutoMapper;

namespace GreenDot.API.MapperProfiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Entities.Course, Models.CourseDto>();
            CreateMap<Models.CourseForCreationDto, Entities.Course>()
                .ForMember(dest =>
                    dest.AuthorId,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore());
        }
    }
}