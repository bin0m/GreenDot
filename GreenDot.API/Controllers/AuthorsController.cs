using System;
using System.Collections.Generic;
using AutoMapper;
using GreenDot.API.Entities;
using GreenDot.API.Models;
using GreenDot.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GreenDot.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                                       throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            IEnumerable<Author> authors = _courseLibraryRepository.GetAuthors();
            IEnumerable<AuthorDto> authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(authorsDto);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAuthor(Guid id)
        {
            Author author = _courseLibraryRepository.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            AuthorDto authorDto = _mapper.Map<AuthorDto>(author);

            return Ok(authorDto);
        }

    }
}