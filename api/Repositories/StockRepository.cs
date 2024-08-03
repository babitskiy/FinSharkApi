using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
            => _context = context;

        public Task<List<Stock>> GetAllAsync()
            => _context.Stocks.ToListAsync();
    }
}