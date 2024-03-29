using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Switch.Domain.Entities;
using Switch.Infra.Data.Config;

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
            public DbSet<Postagem> Postagens { get; set; }
            public DbSet<StatusRelacionamento> StatusRelacionamento { get; set; }
            public DbSet<Grupo> Grupos { get; set; }
            public DbSet<Identificacao> Identificacoes { get; set; }
            public DbSet<Amigo> Amigos { get; set; }
            public DbSet<Comentario> Comentarios { get; set; }
            public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; }
            public DbSet<LocalTrabalho> LocaisTrabalho { get; set; }
            public DbSet<ProcurandoPor> ProcurandoPor { get; set; }

            public SwitchContext(DbContextOptions options) : base (options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
                modelBuilder.ApplyConfiguration(new PostagemConfiguration());
                modelBuilder.ApplyConfiguration(new GrupoConfiguration());
                modelBuilder.ApplyConfiguration(new UsuarioGrupoConfiguration());
                modelBuilder.ApplyConfiguration(new AmigoConfiguration());
                modelBuilder.ApplyConfiguration(new ComentarioConfiguration());
                modelBuilder.ApplyConfiguration(new StatusRelacionamentoConfiguration());
                modelBuilder.ApplyConfiguration(new ProcurandoPorConfiguration());
                
                base.OnModelCreating(modelBuilder);
            }
        }
    }
