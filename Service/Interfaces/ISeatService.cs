namespace Repository.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<ResponseSeat>> GetAllSeatAsync();
        Task<ResponseSeat?> GetSeatByIdAsync(int id);
        Task<ResponseSeat> CreateSeatAsync(CreateSeatModel seat);
        Task<ResponseSeat?> UpdateSeatAsync(int id, UpdateSeatModel seat);
        Task<bool> DeleteSeatAsync(int id);
    }
}