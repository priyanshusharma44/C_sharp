namespace AppointmentManagement.Models
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string? UserEmail { get; set; } = null!; 
        public string UserPassword { get; set; } 

    }
}
