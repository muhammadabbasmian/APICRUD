using APICRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace APICRUD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Products1 : ControllerBase
    {
        DataBaseContext _context;


        public Products1(DataBaseContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<JsonResult> GetAsync()
        {
            var produ1 = await _context.products.ToListAsync();
            return new JsonResult(produ1);
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> GetbyID(int id)
        {

            var findcategorySingle = await _context.products.Where(i => i.CategoryId == id).ToListAsync();

            return new JsonResult(findcategorySingle);
        } 
    }
    
}
