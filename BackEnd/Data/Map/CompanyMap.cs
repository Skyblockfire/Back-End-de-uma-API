using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Map
{
    public class CompanyMap : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RazaoSocial).IsRequired();
            builder.Property(x => x.NomeFantasia).IsRequired();
            builder.Property(x => x.CNPJ).IsRequired();
            builder.Property(x => x.DataAbertura).IsRequired();
            builder.Property(x => x.CNAE).IsRequired();
            builder.Property(x => x.NaturezaJuridica).IsRequired();
            builder.Property(x => x.CEP).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Rua).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.Complemento);
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.Capital).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
