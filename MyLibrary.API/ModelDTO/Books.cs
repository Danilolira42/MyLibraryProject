namespace MyLibrary.API.ModelDTO;

public class Books
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public float Price { get; set; }

    public int Stock { get; set; }

    public string Genre { get; set; } = string.Empty;

}
