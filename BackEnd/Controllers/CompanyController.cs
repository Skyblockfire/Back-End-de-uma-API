using BackEnd.Models;
using BackEnd.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.DTOs;
using System.Linq;
using BackEnd.Enums;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepositorio _companyRepositorio;
        public CompanyController(ICompanyRepositorio companyRepositorio)
        {
            _companyRepositorio = companyRepositorio;
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<CompanyModel>>> BuscarTodasCompanies()
        {
            List<CompanyModel> companies = await _companyRepositorio.BuscarTodasCompanies();
            return Ok(companies);
        }
        [HttpGet("table")]
        public async Task<ActionResult<List<CompanyDto>>> BuscarParaTabela()
        {
            List<CompanyModel> companies = await _companyRepositorio.BuscarParaTabela();
            List<CompanyDto> companiesDTO = companies.Select(e => new CompanyDto
            {
                Id = e.Id,
                NomeFantasia = e.NomeFantasia,
                CNPJ = e.CNPJ,
                Cidade = e.Cidade,
                Telefone = e.Telefone,
                Capital = e.Capital,
                Status = e.Status.GetDescription()
            }).ToList();
            
            return Ok(companiesDTO);
        }
            
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyModel>> BuscarPorId(int id)
        {
            CompanyModel company = await _companyRepositorio.BuscarPorId(id);
            return Ok(company);
        }
        [HttpGet("status={status}")]
        public async Task<ActionResult<List<CompanyModel>>> BuscarPorStatus(StatusAtual status)
        {
            List<CompanyModel> companies = await _companyRepositorio.BuscarPorStatus(status);
            return Ok(companies);
        }
        [HttpPost]
        public async Task<ActionResult<CompanyModel>> Cadastrar([FromBody] CompanyModel companyModel)
        {
            CompanyModel company = await _companyRepositorio.Adicionar(companyModel);
            return Ok(company);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<CompanyModel>> Atualizar([FromBody] CompanyModel companyModel, int id)
        {
            companyModel.Id = id;
            CompanyModel company = await _companyRepositorio.Atualizar(companyModel, id);
            return Ok(company);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<CompanyModel>> Apagar([FromBody] CompanyModel companyModel, int id)
        {
            bool apagado = await _companyRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
