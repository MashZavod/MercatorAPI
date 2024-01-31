using Microsoft.EntityFrameworkCore;
using MercatorAPI.Modules;

namespace MercatorAPI.Data
{
    public class CarDataContext : DbContext
    {
        private readonly DbContextOptions<CarDataContext> options;
        
        public CarDataContext(DbContextOptions<CarDataContext> options) : base(options) 
        {
            this.options = options;
        }
        public DbSet<CarHolder> carholder { get; set; }
    }
}