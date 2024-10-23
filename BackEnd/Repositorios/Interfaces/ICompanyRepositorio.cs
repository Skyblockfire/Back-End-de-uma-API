using BackEnd.Enums;
using BackEnd.Models;

namespace BackEnd.Repositorios.Interfaces
{
    public interface ICompanyRepositorio
    {
        Task<List<CompanyModel>> BuscarTodasCompanies();
        Task<List<CompanyModel>> BuscarParaTabela();
        Task<CompanyModel> BuscarPorId(int id);
        Task<List<CompanyModel>> BuscarPorStatus(StatusAtual status);
        Task<CompanyModel> Adicionar(CompanyModel company);
        Task<CompanyModel> Atualizar(CompanyModel company, int id);
        Task<bool> Apagar(int id);
    }
}
