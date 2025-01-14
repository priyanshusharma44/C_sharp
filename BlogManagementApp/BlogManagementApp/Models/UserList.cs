using System;
using System.Collections.Generic;

namespace BlogManagementApp.Models;

public partial class UserList
{
    public short UserId { get; set; }

    public string FullName { get; set; }

    public string EmailAddress { get; set; }

    public string UserPhoto { get; set; }

    public string UserRole { get; set; }

    public string UserPassword { get; set; }

    public string CurrentAddress { get; set; }

    public string PhoneNumber { get; set; }

    public virtual ICollection<BlogContent> BlogContentCancleUsers { get; set; } = new List<BlogContent>();

    public virtual ICollection<BlogContent> BlogContentUploadeUsers { get; set; } = new List<BlogContent>();
}
