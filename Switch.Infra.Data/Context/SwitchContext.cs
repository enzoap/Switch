using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Context
{
    
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SwitchContext>
        {
            private readonly IConfiguration _configuration;
            public SwitchContext CreateDbContext(string[] args)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Switch.Api"))
                    .AddJsonFile("config.json")
                    .Build();
                var connectionString = config.GetConnectionString("SwitchDB");
                var builder = new DbContextOptionsBuilder<SwitchContext>();
                builder.UseMySql(connectionString);
                return new SwitchContext(builder.Options);
            }
        }
        public class SwitchContext : DbContext
        {
            public DbSet<Usuario> Usuarios { get; set; }
            public SwitchContext(DbContextOptions options) : base (options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Usuario>(entity =>
                {
                    entity.HasKey(u => u.Id);
                    
                    entity.Property(u => u.Nome)
                        .IsRequired()
                        .HasMaxLength(400);
                    
                    
                });
                
                base.OnModelCreating(modelBuilder);
            }
        }
    }
