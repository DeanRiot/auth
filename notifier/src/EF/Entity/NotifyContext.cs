using Microsoft.EntityFrameworkCore;

namespace notifier.EF.Entity
{
    public class NotifyContext:DbContext
    {
        public NotifyContext(DbContextOptions options):base(options) { }
        public virtual DbSet<SMS> SMS { get; set; }
        public virtual DbSet<MAIL> MAIL{ get; set; }
        public virtual DbSet<Communication> Communication { get; set; }

    }
}
