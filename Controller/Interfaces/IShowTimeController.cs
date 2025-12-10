using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface IShowTimeController
    {
        public Task<ResponseShowTime?> CreateShowTime(CreateShowTimeModel showTimeModel);

        public Task<IEnumerable<ResponseShowTime>> GetAllShowTime();

        public Task<ResponseShowTime?> GetShowTimeById(int id);

        public Task<IActionResult> DeleteShowTime(int id);

        public Task<ResponseShowTime?> UpdateShowTime(int id, UpdateShowTimeModel showTimeModel);
    }
}