namespace CinemaProject.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task<IEnumerable<ResponseShowTime>> GetAllShowTimeAsync();
        Task<ResponseShowTime?> GetShowTimeByIdAsync(int id);
        Task<ResponseShowTime> CreateShowTimeAsync(CreateShowTimeModel user);
        Task<ResponseShowTime?> UpdateShowTimeAsync(int id, UpdateShowTimeModel user);
        Task<bool> DeleteShowTimeAsync(int id);
    }
}