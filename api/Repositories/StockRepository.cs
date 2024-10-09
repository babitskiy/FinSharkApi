using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
            => _context = context;

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);
            
            if (stockModel is null)
                return null;

            _context.Remove(stockModel);

            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
            //=> await _context.Stocks.Include(s => s.Comments).ToListAsync();
        {
            var stocks = _context.Stocks.Include(s => s.Comments).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending 
                        ? stocks.OrderByDescending(s => s.Symbol)
                        : stocks.OrderBy(s => s.Symbol);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
            => await _context.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<bool> StockExists(int id)
            => await _context.Stocks.AnyAsync(s => s.Id == id);

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto request)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (existingStock is null)
                return null;

            existingStock.Symbol = request.Symbol;
            existingStock.CompanyName = request.CompanyName;
            existingStock.Purchase = request.Purchase;
            existingStock.LastDiv = request.LastDiv;
            existingStock.Industry = request.Industry;
            existingStock.MarketCap = request.MarketCap;

            await _context.SaveChangesAsync();

            return existingStock;
        }
    }
}