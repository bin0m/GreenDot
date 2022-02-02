using System;
using System.Collections.Generic;
using GreenDot.API.Entities;
using GreenDot.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenDot.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
            
        public AuthorsController(ICourseLibraryRepository courseLibraryRepository)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                                       throw new ArgumentNullException(nameof(courseLibraryRepository));
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            IEnumerable<Author> authors = _courseLibraryRepository.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAuthor(Guid id)
        {
            Author author = _courseLibraryRepository.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

    }
}