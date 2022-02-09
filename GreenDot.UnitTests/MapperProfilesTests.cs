using AutoMapper;
using GreenDot.API.MapperProfiles;
using GreenDot.API.Models;
using Xunit;

namespace GreenDot.UnitTests
{
    public class MapperProfilesTests
    {
        [Fact]
        public void AllMapperProfiles_ShouldBeValid()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<AuthorsProfile>();
                cfg.AddProfile<CoursesProfile>();
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}
