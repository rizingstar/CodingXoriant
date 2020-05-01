using System;
using Microsoft.EntityFrameworkCore;

namespace CodingXoriant.Model
{
    public class PresidentContext: DbContext
    {
        public PresidentContext(DbContextOptions<PresidentContext> options) : base(options)
        {
        }

        public DbSet<President> Presidents { get; set; }

        internal bool Any(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
