using Library.Application.Interfaces;
using Library.Model.Models;
using Library.Persistence.DB;

namespace Library.Persistence.Services;

public class AuthorService : GenericService<Author>, IAuthorService
{
    public AuthorService(DBContext dbContext) : base(dbContext)
    {
    }
}