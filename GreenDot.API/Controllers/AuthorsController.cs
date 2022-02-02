using System;
using GreenDot.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenDot.API.Controllers
{
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                                       throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        [HttpGet("api/authors")]
        public IActionResult GetAuthors()
        {
            var authors = _courseLibraryRepository.GetAuthors();
            return new JsonResult(authors);
        }        
    }
}