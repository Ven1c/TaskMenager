using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Domain;
namespace Project.Application.Interfaces
{
    public interface IProjectDbContext
    {
        DbSet<Project_> Projects_ { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
