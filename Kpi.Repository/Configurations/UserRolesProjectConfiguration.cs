using Kpi.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Repository.Configurations
{
    public class UserRolesProjectConfiguration
    {

        public void Configure(EntityTypeBuilder<UserRolesProject> builder)
        {
            builder.HasKey(ur => ur.Id);

            builder.HasOne(ur => ur.User)
                   .WithMany(u => u.UserRolesProjects)
                   .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Role)
                   .WithMany(r => r.UserRolesProjects)
                   .HasForeignKey(ur => ur.RoleId);

            builder.HasOne(ur => ur.Project)
                .WithMany(u => u.UserRolesProjects)
                .HasForeignKey(ur => ur.ProjectId);

            builder.ToTable("UserRolesProject");
        }
    }
}
