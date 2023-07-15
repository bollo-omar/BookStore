using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Models.Domain
{
    public class Book
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Isbn { get; set; }
        [Required] public int TotalPages { get; set; }
        [Required] public int AuthorId { get; set; }
        [Required] public int PublisherId { get; set; }
        [Required] public int GenreId { get; set; }
        [NotMapped] public string? AuthorName { set; get; }
        [NotMapped] public string? PublisherName { set; get; }
        [NotMapped] public string? GenreName { set; get; }
        [NotMapped] public List<SelectListItem>? AuthorList { get; set; }
        [NotMapped] public List<SelectListItem>? PublisherList { get; set; }
        [NotMapped] public List<SelectListItem>? GenreList { get; set; }
    }
}