using Crud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess.Configuration
{
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {

            // Definindo chave primária
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Sexo)
                .IsRequired()
                .HasMaxLength(1);

            builder.Property(e => e.Idade)
                .IsRequired();

            builder.Property(e => e.Hobby)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.DataNascimento)
               .IsRequired();
        }
    }
}
