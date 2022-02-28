using System.ComponentModel.DataAnnotations;
using GreenDot.API.ValidationAttributes;

namespace GreenDot.API.Models
{
    [CourseTitleMustBeDifferentFromDescription]
    public class CourseForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        
        [MaxLength(1500)]
        public string Description { get; set; } 
    }
}