using AutoMapper;
using GreenDot.API.MapperProfiles;
using GreenDot.API.Models;
using Xunit;

namespace GreenDot.UnitTests
{
    public class MapperProfilesTests
    {
        [Fact]
        public void AuthorsProfile_ShouldBeValid()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<AuthorsProfile>();
            });
            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void CoursesProfile_ShouldBeValid()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<CoursesProfile>();
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}
