using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Domain;
using Project.Application.Interfaces;
using Project.Persistence.EntityTypeConfiguration;
namespace Project.Persistence
{
    public class ProjectsDbContext : DbContext, IProjectDbContext
    {
        public DbSet<Project_> Projects_ { get; set; }
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(Builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;");
        }
    }
}
