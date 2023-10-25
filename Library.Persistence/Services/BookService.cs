using Library.Application.Interfaces;
using Library.Model.Models;
using Library.Persistence.DB;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Services;

public class BookService : GenericService<Book>, IBookService
{
    public BookService(DBContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Book>> GetBooks(int authorId, int pageNumber, int pageSize)
    {
        var skip = (pageNumber - 1) * pageSize;

        var books = await _dbContext.Books
            .Where(x => x.AuthorId == authorId)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
        
        return books;
    }
}