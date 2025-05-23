using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Sale
{
    public int IdSal { get; set; }

    public int ToyId { get; set; }

    public DateTime Date { get; set; }

    public int CountSal { get; set; }

    public virtual Toy Toy { get; set; } = null!;
}
