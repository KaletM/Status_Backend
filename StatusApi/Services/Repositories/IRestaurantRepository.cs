using StatusApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatusApi.Services.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurantsAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task AddRestaurantAsync(Restaurant restaurant);
        Task UpdateRestaurantAsync(Restaurant restaurant);
        Task DeleteRestaurantAsync(int id);
    }
}