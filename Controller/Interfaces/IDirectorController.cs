using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Service.Interfaces
{
    public interface IDirectorController
    {
        Task<ResponseDirector?> CreateDirector(CreateDirectorModel directorModel);

        Task<IEnumerable<ResponseDirector>> GetAllDirectors();

        Task<ResponseDirector?> GetDirectorById(int id);

        Task<IActionResult> DeleteDirector(int id);

        Task<ResponseDirector?> UpdateDirector(int id, UpdateDirectorModel directorModel);
    }
}
