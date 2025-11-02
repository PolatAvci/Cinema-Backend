public class ResponseRefresh
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
    public required ResponseUser User { get; set; }
}