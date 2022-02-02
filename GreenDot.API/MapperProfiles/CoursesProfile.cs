using AutoMapper;
using GreenDot.API.Entities;
using GreenDot.API.Models;

namespace GreenDot.API.MapperProfiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}