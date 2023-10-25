using Library.Model.Models;
namespace Library.Application.Interfaces;

public interface IBookService : IGenericService<Book>
{
    Task<List<Book>> GetBooks(int authorId, int pageNumber, int pageSize);
}