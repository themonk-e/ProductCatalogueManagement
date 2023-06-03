using System;
using System.Collections.Generic;

namespace catologue_ef.newEntities;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public double ProductPrice { get; set; }

    public int ProductQuantity { get; set; }

    public string ProductBrand { get; set; } = null!;

    public string CategoryId { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductSpec> ProductSpecs { get; set; } = new List<ProductSpec>();
}
