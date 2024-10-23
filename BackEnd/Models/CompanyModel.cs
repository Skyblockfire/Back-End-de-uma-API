using BackEnd.Enums;

namespace BackEnd.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public required string RazaoSocial { get; set; }
        public required string NomeFantasia { get; set; }
        public required string CNPJ { get; set; }
        public DateTimeOffset? DataAbertura { get; set; }
        public required string CNAE { get; set; }
        public required string NaturezaJuridica { get; set; }
        public required string CEP { get; set; }
        public required string Cidade { get; set;}
        public required string Rua { get; set;}
        public required string Bairro { get; set;}
        public required string Numero { get; set; }
        public required string Estado { get; set; }
        public string? Complemento { get; set; }
        public required string Telefone { get; set;}
        public required string Capital { get; set;}
        public required StatusAtual Status { get; set; }
    }
}
