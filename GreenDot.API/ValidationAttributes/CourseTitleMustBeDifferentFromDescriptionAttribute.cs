using System.ComponentModel.DataAnnotations;
using GreenDot.API.Models;

namespace GreenDot.API.ValidationAttributes
{
    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (CourseForManipulationDto) validationContext.ObjectInstance;
            if (course.Title == course.Description)
            {
                return new ValidationResult("The provided description should be different from title.",
                    new[] { nameof(CourseForManipulationDto) });
            }
            return ValidationResult.Success;
        }
    }
}