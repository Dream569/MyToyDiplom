using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Toy> Toys { get; set; } = new List<Toy>();
}
