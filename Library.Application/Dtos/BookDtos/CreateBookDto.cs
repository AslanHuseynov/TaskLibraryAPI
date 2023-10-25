namespace Library.Application.Dtos.BookDtos;

public class CreateBookDto
{
    public required string Description { get; set; }
    public int AuthorId { get; set; }
}