using System;
using System.Collections.Generic;

namespace TestingRestfulApi.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public decimal Fee { get; set; }
}
