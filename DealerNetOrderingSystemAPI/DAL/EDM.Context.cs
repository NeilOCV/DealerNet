﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EDM : DbContext
    {
        public EDM()
            : base("name=EDM")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<items> items { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<stock_levels> stock_levels { get; set; }
    }
}
