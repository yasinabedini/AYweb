using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AYweb.Dal.Entities.Products;

namespace AYweb.Dal.Entities.Order;

public class OrderLine
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int OrderId { get; set; }

    [Required]
    public int Count { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public int SumPrice { get; set; }


    public Order Order { get; set; }
    public Product? Product { get; set; }

}