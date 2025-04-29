using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Provider
{
    public int ProviderId { get; set; }

    public string ProviderName { get; set; } = null!;

    public int? Phone { get; set; }

    public string DeliveryTime { get; set; } = null!;
}
