using Microsoft.AspNetCore.Mvc;

namespace Controller.Interfaces
{
    public interface ISeatController
    {
        public Task<ResponseSeat?> CreateSeat(CreateSeatModel seatModel);

        public Task<IEnumerable<ResponseSeat>> GetAllSeat();

        public Task<ResponseSeat?> GetSeatById(int id);

        public Task<IActionResult> DeleteSeat(int id);

        public Task<ResponseSeat?> UpdateSeat(int id, UpdateSeatModel seatModel);
    }
}