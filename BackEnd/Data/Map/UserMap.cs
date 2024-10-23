using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.CPF).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.EmpresaId);
        }
    }
}
