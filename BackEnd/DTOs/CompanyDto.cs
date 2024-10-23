namespace BackEnd.DTOs
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public required string NomeFantasia { get; set; }  
        public required string CNPJ { get; set; }  
        public required string Cidade { get; set; }
        public required string Telefone { get; set;}
        public required string Capital { get; set;}
        public required string Status { get; set;}
    }
}
