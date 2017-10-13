namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EDC : DbContext
    {
        public DbSet<orders> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<orders>().Property(o => o.id).HasMaxLength(36);
            modelBuilder.Entity<orders>().Property(o => o.id).IsRequired();
            modelBuilder.Entity<orders>().Property(o => o.time_stamp).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
        
    }

}