﻿using System.ComponentModel.DataAnnotations;
using GreenDot.API.ValidationAttributes;

namespace GreenDot.API.Models
{
    [CourseTitleMustBeDifferentFromDescription]
    public abstract class CourseForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "Title shouldn't have more than 100 characters.")]
        public string Title { get; set; }

        [MaxLength(1500)]
        public virtual string Description { get; set; }
    }
}