using BackEnd.Enums;

namespace BackEnd.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public required string Telefone { get; set; }
        public required StatusAtual Status { get; set; }
        public int? EmpresaId { get; set; }
        public CompanyModel? Company { get; set; }

    }
}
