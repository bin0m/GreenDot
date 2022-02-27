using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GreenDot.API.Entities;
using GreenDot.API.Models;
using GreenDot.API.Services;
using GreenDot.API.ValueProviders;
using Microsoft.AspNetCore.Mvc;

namespace GreenDot.API.Controllers
{
    [ApiController]
    [Route("api/authorcollection")]
    public class AuthorCollectionController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorCollectionController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository 
                                       ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthorCollection(
            [FromQuery][CommaSeparated] IEnumerable<string> ids)
        {
            IEnumerable<Guid> guids = ids.Select(id => Guid.Parse(id));
            IEnumerable<Author> authors = _courseLibraryRepository.GetAuthors(guids);
            IEnumerable<AuthorDto> authorsToReturn = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(authorsToReturn);
        }

        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection(
            IEnumerable<AuthorForCreationDto> authors)
        {
            if (authors == null || !authors.Any())
            {
                return BadRequest();
            }

            var authorEntities = _mapper.Map<IEnumerable<Author>>(authors)
                .ToList();

            foreach (var authorEntity in authorEntities)
            {
                _courseLibraryRepository.AddAuthor(authorEntity);
            }

            _courseLibraryRepository.Save();

            var authorsToReturn = _mapper.Map<IEnumerable<AuthorDto>>(authorEntities);

            return Ok();

        }
    }
}