using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Queries.Common;

public class ProductResult
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public required string ShortDescription { get; set; }

    public required string MainDescription { get; set; }

    public bool IsActive { get; set; }

    public required string ImageName { get; set; }

    public bool InventoryStatus { get; set; }

    public int Price { get; set; }

    public int DiscountedPercent { get; set; }

    public int Inventory { get; set; }

    public bool IsSpecial { get; set; }    
}
