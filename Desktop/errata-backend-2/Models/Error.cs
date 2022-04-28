namespace ErrataManager.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Error {
    [Key]
    public int Id { get; set; }

    public string? ErrorName { get; set; }

    public string? ErrorType { get; set; }

    public string? Location { get; set; }

    public string? Description { get; set; }

    
    public int BookId { get; set; }

    [ForeignKey("BookId")]

    [JsonIgnore]
    public Book? Book { get; set; }

    public string? Decision { get; set; }
}