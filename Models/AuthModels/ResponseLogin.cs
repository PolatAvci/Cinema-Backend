public class ResponseLogin
{
    public required ResponseUser User { get; set; }
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}