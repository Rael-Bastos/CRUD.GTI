using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.GTI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.GTI.Infra.Configuration
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tbl_Cliente");

            builder.HasKey(a => a.IdCliente);

            builder.HasOne(x => x.EnderecoCliente)
                .WithOne(x => x.Cliente).HasForeignKey<EnderecoCliente>(c => c.IdCliente);
                

             }  
    }
}
