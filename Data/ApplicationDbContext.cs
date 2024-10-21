using Microsoft.EntityFrameworkCore;
using ApiPdtTechLeilao.Models;

namespace ApiPdtTechLeilao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allotment> Allotments { get; set; }
        public DbSet<AuctionImage> AuctionImages { get; set; }
    }
}
