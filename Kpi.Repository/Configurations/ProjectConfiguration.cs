using Kpi.Core.Models.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Repository.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.ProjectName).IsRequired();

            builder.HasOne(p => p.Sprint)
                   .WithMany(s => s.Projects)
                   .HasForeignKey(p => p.SprintId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasMany(p => p.UserRolesProjects)
                   .WithOne(urp => urp.Project)
                   .HasForeignKey(urp => urp.ProjectId);

        }
    }
}
