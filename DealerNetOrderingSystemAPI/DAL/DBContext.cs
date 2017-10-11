namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBContext : DbContext
    {
        public DbSet<orders> Orders { get; set; }
        public DbSet<categories> Categories { get; set; }
    }

}