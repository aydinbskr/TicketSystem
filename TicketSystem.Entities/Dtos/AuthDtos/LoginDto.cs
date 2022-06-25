namespace TicketSystem.Entities.Dtos
{
    public class LoginDto
    {
        public string LoginType { get; set; } = "Customer";
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
