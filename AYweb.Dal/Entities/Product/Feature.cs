using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AYweb.Dal.Entities.Products;

public class Feature
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Value { get; set; }

    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}