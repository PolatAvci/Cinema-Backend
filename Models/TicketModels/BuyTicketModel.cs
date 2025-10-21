public class BuyTicketModel
{
    public int UserId { get; set; }
    public Role Role { get; set; } = Role.User;
}