using System;
using System.Collections.Generic;

namespace EFCORECRUDASP.Models;

public partial class TodoList
{
    public long Sn { get; set; }

    public string TaskName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly EntryDate { get; set; }

    public DateOnly DeadLine { get; set; }

    public DateOnly? CompleteDate { get; set; }
}
