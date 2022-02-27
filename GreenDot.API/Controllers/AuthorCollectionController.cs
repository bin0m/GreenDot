using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GreenDot.API.Entities;
using GreenDot.API.Helpers;
using GreenDot.API.Models;
using GreenDot.API.Services;
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

        [HttpGet("({ids})", Name = "GetAuthorCollection")]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthorCollection(
            [FromRoute][ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                return BadRequest();
            }
            IEnumerable<Author> authors = _courseLibraryRepository.GetAuthors(ids);

            if (ids.Count() != authors.Count())
            {
                return NotFound();
            }

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
            string ids = string.Join(",", authorsToReturn.Select(author => author.Id));

            return CreatedAtRoute(
                "GetAuthorCollection", 
                new {ids = ids},
                authorsToReturn
                );
        }
    }
}