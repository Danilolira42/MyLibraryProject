using Library.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using MyLibrary.API.ModelDTO;

namespace MyLibrary.API.Controllers;
[Route("GetLibrary")]
[ApiController]
public class BooksController : ControllerBase
{
    private BooksDbContext _db;

    public BooksController(BooksDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));    
    }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IActionResult GetLibrary()
    {
        var Books = _db.Books.ToList();

        return Ok(Books);
    }

    [HttpGet("GetBooksById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Books>> GetBookById(int id)
    {
        var BooksById = await _db.Books.FindAsync(id);

        return Ok(BooksById);
    }

    [HttpPost("CreateBooks")]
    [ProducesResponseType(StatusCodes.Status201Created)]

    public IActionResult CreateBooks(Books newBook)
    {

        var newBooks = _db.Books.Add(newBook);

        _db.SaveChanges();

        return Ok(newBooks.Entity);

    }

    [HttpPut("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult<BooksDbContext>> UpdateBooks([FromBody] Books updateBooks, [FromRoute] int Id)
    {
        var currencyBooks = await _db.Books.FindAsync(Id);


        currencyBooks.Title = updateBooks.Title;
        currencyBooks.Author = updateBooks.Author;
        currencyBooks.Price = updateBooks.Price;
        currencyBooks.Stock = updateBooks.Stock;
        currencyBooks.Genre = updateBooks.Genre;

        _db.SaveChanges();

        return NoContent();

    }

    [HttpDelete("{Id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBooks([FromRoute] int Id)
    {

        var deleteBooks = await _db.Books.FindAsync(Id);
        _db.Books.Remove(deleteBooks);

        if(deleteBooks == null)
            return NotFound($"O livro {Id} não foi encontrado!");

        await _db.SaveChangesAsync();

        return Ok($"Produto {Id} foi excluído");

    }
}