namespace Library.Application.Dtos.BookDtos;

public class GetBookDto
{
    public int authorId { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}