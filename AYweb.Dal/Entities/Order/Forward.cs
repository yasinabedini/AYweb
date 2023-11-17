using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AYweb.Dal.Entities.Order;

public class Forward
{
    [Key]
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Address { get; set; }
    public bool IsForward { get; set; }
    public string? TrackingCode { get; set; }

    [ForeignKey("OrderId")]
    public Order Order { get; set; }
}