using System;
using System.Collections.Generic;

namespace BlogManagementApp.Models;

public partial class BlogContent
{
    public short Bid { get; set; }

    public string SectionHeading { get; set; }

    public string SectionImage { get; set; }

    public string SectionDescription { get; set; }

    public string PostDate { get; set; }

    public short? UploadeUserId { get; set; }

    public short? CancleUserId { get; set; }

    public DateOnly CancleDate { get; set; }

    public string ReasonForCancle { get; set; }

    public virtual UserList CancleUser { get; set; }

    public virtual UserList UploadeUser { get; set; }
}
