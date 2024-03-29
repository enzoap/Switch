using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Sobrenome).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Senha).HasMaxLength(10).IsRequired();
            builder.Property(u => u.Sexo).IsRequired();
            builder.Property(u => u.UrlFoto).HasMaxLength(400).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(400).IsRequired();
            builder.Property(u => u.DateNascimento).IsRequired();
            builder.HasMany(u => u.Comentarios).WithOne(c => c.Usuario);
//            builder.HasOne(u => u.Identificacao)
//                .WithOne(i => i.Usuario)
//                .HasForeignKey<Identificacao>(i => i.Usuario);
//            builder.HasMany(u => u.Postagens)
//                .WithOne(p => p.Usuario);
        }
    }
}