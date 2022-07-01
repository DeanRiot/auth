using Microsoft.EntityFrameworkCore;

namespace notify.Models.EF
{
    public class NotifyContext : DbContext
    {
        private NotifyContext() : base() { }
        public NotifyContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<SMS> SMS { get; set; }
        public virtual DbSet<MAIL> MAIL { get; set; }
        public virtual DbSet<Communication> Communication { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
             .Entity<MAIL>()
             .Property(e => e.mail_id)
             .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder
             .Entity<Communication>()
             .Property(e => e.id)
             .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder
             .Entity<SMS>()
             .Property(e => e.sms_id)
             .HasDefaultValueSql("gen_random_uuid()");
        }

    }
}
