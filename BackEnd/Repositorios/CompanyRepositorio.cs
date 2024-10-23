using BackEnd.Data;
using BackEnd.Enums;
using BackEnd.Models;
using BackEnd.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositorios
{
    public class CompanyRepositorio : ICompanyRepositorio
    {
        private readonly BackEndDBContext _dbContext;
        public CompanyRepositorio(BackEndDBContext backEndDBContext)
        {
            _dbContext = backEndDBContext;
        }
        public async Task<CompanyModel> BuscarPorId(int id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CompanyModel>> BuscarTodasCompanies()
        {
            return await _dbContext.Companies.ToListAsync();
        }
        public async Task<List<CompanyModel>> BuscarParaTabela()
        {
            return await _dbContext.Companies.ToListAsync();
        }
        public async Task<List<CompanyModel>> BuscarPorStatus(StatusAtual status)
        {
            return await _dbContext.Companies
                                .Where(e => e.Status == status)
                                .ToListAsync();
        }
        public async Task<CompanyModel> Adicionar(CompanyModel company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company;
        }
        public async Task<CompanyModel> Atualizar(CompanyModel company, int id)
        {
            CompanyModel CompanyById = await BuscarPorId(id);

            if (CompanyById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            CompanyById.Id = company.Id;
            CompanyById.RazaoSocial = company.RazaoSocial;
            CompanyById.NomeFantasia = company.NomeFantasia;
            CompanyById.CNPJ = company.CNPJ;
            CompanyById.DataAbertura = company.DataAbertura;
            CompanyById.CNAE = company.CNAE;
            CompanyById.NaturezaJuridica = company.NaturezaJuridica;
            CompanyById.CEP = company.CEP;
            CompanyById.Cidade = company.Cidade;
            CompanyById.Rua = company.Rua;
            CompanyById.Bairro = company.Bairro;
            CompanyById.Numero = company.Numero;
            CompanyById.Estado = company.Estado;
            CompanyById.Complemento = company.Complemento;
            CompanyById.Telefone = company.Telefone;
            CompanyById.Capital = company.Capital;
            CompanyById.Status = company.Status;

            _dbContext.Companies.Update(CompanyById);
            await _dbContext.SaveChangesAsync();

            return CompanyById;
        }
        public async Task<bool> Apagar(int id)
        {
            CompanyModel CompanyById = await BuscarPorId(id);

            if (CompanyById == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Companies.Remove(CompanyById);
            await _dbContext.SaveChangesAsync();

            return true;
        }



    }
}
