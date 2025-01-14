using System.Collections.Generic;

namespace StudentAppWithLogin.Models
{
    public partial class UserList
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string LoginId { get; set; } = null!;

        public string LoginPassword { get; set; } = null!;

        public string LoginStatus { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
