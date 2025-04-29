using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Toy
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Photo { get; set; }

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
