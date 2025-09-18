using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLibrary.API.ModelDTO;

[Table("booksregister")]
public class Books
{
    [Key]
    public int BooksId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public double Price { get; set; }

    public int Stock { get; set; }

    public string Genre { get; set; } = string.Empty;

}
