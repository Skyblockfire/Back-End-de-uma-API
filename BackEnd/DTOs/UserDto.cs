namespace BackEnd.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string Telefone { get; set; }
        /*
        public int? EmpresaId { get; set; }
        public CompanyDto? Company { get; set; }*/
    }
}
