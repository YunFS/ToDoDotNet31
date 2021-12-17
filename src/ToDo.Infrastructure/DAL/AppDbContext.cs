using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
