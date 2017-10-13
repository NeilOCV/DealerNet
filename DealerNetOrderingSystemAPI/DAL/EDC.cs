namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EDC : DbContext
    {
        public DbSet<orders> Orders { get; set; }
        public DbSet<items> Items { get; set; }
        public DbSet<categories> Categories { get; set; }
        public DbSet<stock_levels> StockLevels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Formatting the ORDERS table
            modelBuilder.Entity<orders>().Property(o => o.id).HasMaxLength(36);
            modelBuilder.Entity<orders>().Property(o => o.id).IsRequired();
            modelBuilder.Entity<orders>().Property(o => o.items_id).HasMaxLength(36);
            modelBuilder.Entity<orders>().Property(o => o.items_id).IsRequired();
            modelBuilder.Entity<orders>().Property(o => o.time_stamp).IsRequired();
            modelBuilder.Entity<orders>().Property(o => o.quantity).IsRequired();
            #endregion
            
            #region Formatting the ITEMS table
            modelBuilder.Entity<items>().Property(i => i.id).IsRequired();
            modelBuilder.Entity<items>().Property(i => i.id).HasMaxLength(36);
            modelBuilder.Entity<items>().Property(i => i.unit_price).IsRequired();
            modelBuilder.Entity<items>().Property(i => i.unit_price).HasPrecision(8, 2);
            modelBuilder.Entity<items>().Property(i => i.categories_id).IsRequired();
            modelBuilder.Entity<items>().Property(i => i.categories_id).HasMaxLength(36);
            modelBuilder.Entity<items>().Property(i => i.description).IsRequired();
            #endregion

            #region Formatting the CATEGORIES table
            modelBuilder.Entity<categories>().Property(c => c.id).IsRequired();
            modelBuilder.Entity<categories>().Property(c => c.id).HasMaxLength(36);
            modelBuilder.Entity<categories>().Property(c => c.category).IsRequired();
            #endregion

            #region Formatting the STOCK_LEVELS table
            modelBuilder.Entity<stock_levels>().Property(sl => sl.id).HasMaxLength(36);
            modelBuilder.Entity<stock_levels>().Property(sl => sl.id).IsRequired();
            modelBuilder.Entity<stock_levels>().Property(sl => sl.items_id).HasMaxLength(30);
            modelBuilder.Entity<stock_levels>().Property(sl => sl.items_id).IsRequired();
            modelBuilder.Entity<stock_levels>().Property(sl => sl.stock_level).IsRequired();
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        
    }

}