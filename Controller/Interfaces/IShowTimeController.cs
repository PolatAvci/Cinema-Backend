using Microsoft.AspNetCore.Mvc;

namespace CinemaProject.Controller.Interfaces
{
    public interface IShowTimeController
    {
        public Task<ResponseShowTime?> CreateShowTime(CreateShowTimeModel showTimeModel);

        public Task<IEnumerable<ResponseUser>> GetAllShowTime();

        public Task<ResponseUser?> GetShowTimeById(int id);

        public Task<IActionResult> DeleteShowTime(int id);

        public Task<ResponseUser?> UpdateShowTime(int id, UpdateShowTimeModel showTimeModel);
    }
}