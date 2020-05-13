using Microsoft.EntityFrameworkCore;

namespace CodingXoriant.Model
{
    public class PresidentContext: DbContext
    {
        public PresidentContext(DbContextOptions<PresidentContext> options) : base(options)
        {
        }

        public DbSet<President> Presidents { get; set; }
    }
}
