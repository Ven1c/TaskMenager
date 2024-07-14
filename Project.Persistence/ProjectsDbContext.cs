using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Domain;
using Project.Application.Interfaces;
using Project.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Project.Persistence
{
    public class ProjectsDbContext : DbContext, IProjectDbContext
    {
        public DbSet<Project_> Projects_ { get; set; }
        public DbSet<Task_> Tasks_ { get; set; }
        public DbSet<User_> Users_ { get; set; }

        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<User_>().HasData(new User_
            {
                Id = Guid.NewGuid(),
                Login = "admin",
                Password = "admin",
                UserName = "Administrator",
                UserRole = "admin"
            });
            var converter = new ValueConverter<string[], string>(
                    x => string.Join(",", x),
                     x => x.Split(',', StringSplitOptions.RemoveEmptyEntries));
            Builder.Entity<Project_>()
                .Property(e => e.StatusCombination)
                .HasConversion(converter);
                
            Builder.Entity<Project_>()
                .HasMany(tasks => tasks.TasksId);

            Builder.Entity<Task_>()
               .HasOne(user => user.Worker);
            Builder.ApplyConfiguration(new ProjectConfiguration());
                
            base.OnModelCreating(Builder);
                
        }
    
    }
}
