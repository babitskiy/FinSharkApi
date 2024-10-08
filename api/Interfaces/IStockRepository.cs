using api.Dtos.Stock;
using api.Models;
using api.Helpers;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto request);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);
    }
}