using AutoMapper;
using Library.Application.Dtos.AuthorDtos;
using Library.Application.Interfaces;
using Library.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetBook(int id)
        {
            var result = await _authorService.GetEntity(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Author>>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = _mapper.Map<Author>(createAuthorDto);
            var result = await _authorService.AddEntity(author);
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<ActionResult<List<Author>>> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteEntity(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}
