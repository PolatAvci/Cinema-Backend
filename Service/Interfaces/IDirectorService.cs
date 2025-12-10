namespace CinemaProject.Service.Interfaces
{
    public interface IDirectorService
    {
        Task<ResponseDirector?> CreateDirectorAsync(CreateDirectorModel directorModel);
        Task<IEnumerable<ResponseDirector>> GetAllDirectorsAsync();
        Task<ResponseDirector?> GetDirectorByIdAsync(int id);
        Task<ResponseDirector?> UpdateDirectorAsync(int id, UpdateDirectorModel directorModel);
        Task<bool> DeleteDirectorAsync(int id);
    }
}
