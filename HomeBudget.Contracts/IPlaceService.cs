using HomeBudget.Models.Place;

namespace HomeBudget.Contracts
{
    public interface IPlaceService
    {
        Task<bool> CreatePlaceAsync(PlaceCreate model);
        Task<bool> DeletePlaceAsync(int PlaceId);
        Task<List<PlaceListItem>> GetAllPlacesAsync();
        Task<PlaceDetail> GetPlaceByIdAsync(int id);
        void SetUserId(Guid userId);
        Task<bool> UpdatePlaceAsync(PlaceEdit model);
    }
}