using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Supply
{
    public int IdSup { get; set; }

    public int ToyId { get; set; }

    public DateTime Date { get; set; }

    public int CountSup { get; set; }

    public virtual Toy Toy { get; set; } = null!;
}
