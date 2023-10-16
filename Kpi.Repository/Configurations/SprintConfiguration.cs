using Kpi.Core.Models.Sprints;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpi.Repository.Configurations
{
    public class SprintConfiguration
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder.HasMany(s => s.Projects)
            .WithOne(p => p.Sprint)
            .HasForeignKey(p => p.SprintId);
        }
    }
}
