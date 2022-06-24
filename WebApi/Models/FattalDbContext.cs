﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class FattalDbContext : DbContext
    {
        public FattalDbContext(DbContextOptions<FattalDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuAccess>().HasKey(u => new
            {
                u.NodeID,
                u.MenuID,
                u.CompNo
            });
            //modelBuilder.Entity<MenuAccess>()
            //    .HasOne(u => u.node)
            //    .WithMany(u => u.Men)
                //.HasForeignKey(u => u.NodeID);
        }
        public DbSet<User> SYS_Users { get; set; }
        public DbSet<VariableDetails> SYS_VariableDetails { get; set; }
        public DbSet<UserAccess> SYS_UsersAccess { get; set; }
        public DbSet<MenuAccess> SYS_MenuAccess { get; set; }
        public DbSet<Node> SYS_Nodes { get; set; }
        public DbSet<SalesRep> SalesReps { get; set; }
    }
}
