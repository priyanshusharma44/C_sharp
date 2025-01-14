using System.ComponentModel.DataAnnotations;

namespace BlogManagementApp.Models
{
    public class BlogContentEdit
    {
        public short Bid { get; set; }

        public string SectionHeading { get; set; } = null!;

        public string? SectionImage { get; set; }

        public string? SectionDescription { get; set; }

        public string? PostDate { get; set; }

        public short UploadeUserId { get; set; }

        public short? CancelUserId { get; set; }

        public DateOnly? CancelDate { get; set; }

        public string? ReasonForCancel { get; set; }
        public string? EncId { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? BlogFile { get; set; }

        
    }
}