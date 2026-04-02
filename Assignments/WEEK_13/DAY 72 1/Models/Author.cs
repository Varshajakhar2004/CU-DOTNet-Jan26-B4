using LibraryManagementAPI.Models;
using System.Text.Json.Serialization;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    [JsonIgnore]  
    public List<Book> Books { get; set; }
}