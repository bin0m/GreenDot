using System.ComponentModel.DataAnnotations;
using GreenDot.API.ValidationAttributes;

namespace GreenDot.API.Models
{
    public class CourseForUpdateDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "Title shouldn't have more than 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }
    }
}