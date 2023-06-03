using System;
using System.Collections.Generic;

namespace catologue_ef.newEntities;

public partial class ProductSpec
{
    public int SpecId { get; set; }

    public string SpecName { get; set; } = null!;

    public string Value { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
