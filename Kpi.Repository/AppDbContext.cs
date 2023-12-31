﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kpi.Core.Models;
using Kpi.Core.Models.Projects;
using Kpi.Core.Models.Sprints;
using Microsoft.EntityFrameworkCore;
using NLayer.Core;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProject> UserProject { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<Kpi.Core.Models.Tasks.Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
            base.OnModelCreating(modelBuilder);
        }
    }
}