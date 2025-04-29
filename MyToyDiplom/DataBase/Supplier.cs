using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierName { get; set; } = null!;

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public virtual ICollection<Toy> Toys { get; set; } = new List<Toy>();
}
