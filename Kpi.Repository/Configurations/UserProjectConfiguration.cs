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
    public class UserProjectConfiguration
    {

        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.HasKey(ur => ur.Id);

            builder.HasOne(ur => ur.User)
                   .WithMany(u => u.UserProject)
                   .HasForeignKey(ur => ur.UserId);

            builder.HasOne(ur => ur.Project)
                .WithMany(u => u.UserProject)
                .HasForeignKey(ur => ur.ProjectId);

            builder.ToTable("UserRolesProject");
        }
    }
}
