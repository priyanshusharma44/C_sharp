using System;
using System.Collections.Generic;

namespace StudentAppWithLogin.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public decimal Fee { get; set; }

    public int EntryUserId { get; set; }

    public virtual UserList EntryUser { get; set; } = null!;
}
