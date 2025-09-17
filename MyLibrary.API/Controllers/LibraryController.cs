using Microsoft.AspNetCore.Mvc;
using MyLibrary.API.ModelDTO;

namespace MyLibrary.API.Controllers;
[Route("GetLibrary")]
[ApiController]
public class LibraryController : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IActionResult GetLibrary(string request)
    {
        var Books = new List<Books>();

        return Ok();
    }

    [HttpGet("GetBooksById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Books>> GetBookById(int id)
    {
        var BooksById = new Books();

        return Ok(BooksById);
    }

    [HttpPost("CreateBooks")]
    [ProducesResponseType(StatusCodes.Status201Created)]

    public IActionResult CreateBooks(Books request)
    {

        return Ok(request);

    }

    [HttpPut("{Id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public IActionResult UpdateBooks(string request)
    {
        var updateBooks = new Books();

        return NoContent();

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public IActionResult DeleteBooks(int Id)
    {

        var deleteBooks = new Books();

        deleteBooks.Id = Id;
        deleteBooks.Title = "Notebook";
        deleteBooks.Author = "Dell";
        deleteBooks.Price = 5000;
        deleteBooks.Stock = 10;

        return Ok($"Produto {Id} excluído");

    }
}