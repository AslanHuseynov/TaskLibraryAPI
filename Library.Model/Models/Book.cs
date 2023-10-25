﻿namespace Library.Model.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
