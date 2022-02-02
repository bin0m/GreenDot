using System;
using System.Collections.Generic;
using AutoMapper;
using GreenDot.API.Models;
using GreenDot.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenDot.API.Controllers
{
    [ApiController]
    [Route("api/authors/{id}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                                       throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesForAuthor(Guid id)
        {
            if (!_courseLibraryRepository.AuthorExists(id))
            {
                return NotFound(); 
            }
            var courses = _courseLibraryRepository.GetCourses(id);
            var coursesDto = _mapper.Map<IEnumerable<CourseDto>>(courses);

            return Ok(coursesDto);
        }

        [HttpGet("{courseId}")]
        public ActionResult<CourseDto> GetCourseForAuthor(Guid id, Guid courseId)
        {
            if (!_courseLibraryRepository.AuthorExists(id))
            {
                return NotFound();
            }
            var course = _courseLibraryRepository.GetCourse(id,courseId);
            if (course == null)
            {
                return NotFound();
            }
            var courseDto = _mapper.Map<CourseDto>(course);

            return Ok(courseDto);
        }

    }
}