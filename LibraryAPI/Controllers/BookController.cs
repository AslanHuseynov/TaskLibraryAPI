using AutoMapper;
using Library.Application.Dtos.BookDtos;
using Library.Application.Interfaces;
using Library.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks(int pageNumber, int pageSize)
        {
            return await _bookService.GetAllEntity(pageNumber, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var result = await _bookService.GetEntity(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{authorId}")]
        public async Task<ActionResult<Book>> GetBooks(GetBookDto getBookDto)
        {
            var result = await _bookService.GetBooks(getBookDto.authorId, getBookDto.pageNumber, getBookDto.pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> CreateBook(CreateBookDto createBookDto)
        {
            var employee = _mapper.Map<Book>(createBookDto);
            var result = await _bookService.AddEntity(employee);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<Book>>> UpdateEmployee(UpdateBookDto updateBookDto)
        {
            var employee = _mapper.Map<Book>(updateBookDto);
            var result = await _bookService.UpdateEntity(updateBookDto.Id, employee);

            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<ActionResult<List<Book>>> DeleteEmployee(int id)
        {
            var result = await _bookService.DeleteEntity(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }
    }
}