namespace Library.Application.Dtos.BookDtos;

public class UpdateBookDto
{
    public int Id { get; set; }
    public required string Description { get; set; }
}