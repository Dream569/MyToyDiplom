using System;
using System.Collections.Generic;

namespace MyToyDiplom.DataBase;

public partial class Employee
{
    public int EmpoleeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthdayDate { get; set; }

    public string? Adress { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int? Phone { get; set; }

    public string? Photo { get; set; }
}
