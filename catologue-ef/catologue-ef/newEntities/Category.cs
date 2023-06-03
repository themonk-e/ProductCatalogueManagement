using System;
using System.Collections.Generic;

namespace catologue_ef.newEntities;

public partial class Category
{
    public string CategoryId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public double CategoryDescription { get; set; }

    public int CategoryProductCount { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
