using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
                .Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock is null)
            {
                return NotFound();
            }
            
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto request)
        {
            var stockModel = request.ToStockFromCreateDto();
            _context.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto request)
        {
            var stockModel = _context.Stocks.FirstOrDefault(s => s.Id == id);

            if (stockModel is null)
                return NotFound();

            stockModel.Symbol = request.Symbol;
            stockModel.CompanyName = request.CompanyName;
            stockModel.Purchase = request.Purchase;
            stockModel.LastDiv = request.LastDiv;
            stockModel.Industry = request.Industry;
            stockModel.MarketCap = request.MarketCap;

            _context.SaveChanges();

            return Ok(stockModel.ToStockDto());
        }
    }
}