using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.GTI.Domain.Entities;

namespace Projeto.GTI.Infra.Configuration
{
    public class EnderecoClienteConfig : IEntityTypeConfiguration<EnderecoCliente>
    {
        public void Configure(EntityTypeBuilder<EnderecoCliente> builder)
        {
            builder.ToTable("tbl_EnderecoCliente");

            builder.HasKey(a => a.IdCliente);

        }
    }
}
