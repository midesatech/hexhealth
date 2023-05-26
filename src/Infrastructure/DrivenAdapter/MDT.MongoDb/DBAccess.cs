using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MDT.MongoDb.Entities;

namespace MDT.MongoDb
{
    public class DBAccess : DbContext
    {
        public DbSet<EmpleadoEntity> Empleado { set; get; }
        public DBAccess(DbContextOptions<DBAccess> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoEntity>().ToTable("employee");
        }
    }
}