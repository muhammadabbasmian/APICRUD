
using Microsoft.EntityFrameworkCore;

namespace APICRUD.Models

{
    public class DataBaseContext :DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Touches> touches { get; set; }
        public DbSet<Products> products { get; set; }
    }
}
