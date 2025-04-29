using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class User
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? UserRole { get; set; }

    public virtual Role? UserRoleNavigation { get; set; }
}
