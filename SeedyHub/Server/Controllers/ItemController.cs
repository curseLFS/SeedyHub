using Microsoft.AspNetCore.Mvc;

namespace SeedyHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemDetails>>> GetItem()
        {
            var item = await _context.Items.Include(i => i.category).ToListAsync();
            return Ok(item);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var category = await _context.Categories.ToListAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDetails>> GetSingleItem(int id)
        {
            var item = _context.Items
                .Include(i => i.category)
                .FirstOrDefault(i => i.ItemId == id);

            if (item == null)
            {
                return NotFound("Sorry, no item here. :/");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<ItemDetails>>> ItemRegistration(ItemDetails item)
        {
            item.category = null;
            item.DateOfTransaction = DateTime.Now;

            _context.Add(item);

            await _context.SaveChangesAsync();

            return Ok(await GetDbItem());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ItemDetails>>> UpdateItem(ItemDetails items, int id) 
        {
            var dbItem = await _context.Items
                .Include(i => i.category)
                .FirstOrDefaultAsync(ii => ii.CategoryId == id);

            if (dbItem == null)
                return NotFound("Sorry, but no item for you. :/");


            dbItem.ItemName = items.ItemName;
            dbItem.Price = items.Price;
            dbItem.Quantity = items.Quantity;
            dbItem.TotalPrice = items.Price * items.Quantity;
            dbItem.Description = items.Description;
            dbItem.DateOfTransaction = DateTime.Now;
            dbItem.CategoryId = items.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbItem());

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ItemDetails>>> DeleteItem(int id) 
        {
            var itemdb = await  _context.Items
                .Include(i => i.category)
                .FirstOrDefaultAsync(ii => ii.ItemId == id);

            if (itemdb == null)
                return NotFound("Sorry, but no item for you. :/");

            _context.Items.Remove(itemdb);

            await _context.SaveChangesAsync();

            return Ok(await GetDbItem());
        }

        private async Task<List<ItemDetails>> GetDbItem()
        {
            return await _context.Items.Include(i => i.category).ToListAsync();
        }
    }
}
