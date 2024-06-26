using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Domain;

namespace Project.Persistence.EntityTypeConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project_>
    {
        public void Configure(EntityTypeBuilder<Project_> builder) { 
            builder.HasKey(Project_ => Project_.Id);
            builder.HasIndex(Project_ => Project_.Id).IsUnique();
            builder.Property(Project_ => Project_.Name).HasMaxLength(25);
        }
    }
}
