using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Repositorios.Interfaces;
using BackEnd.Repositorios;
using BackEnd.DTOs;
using BackEnd.Enums;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        public UserController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsers()
        {
            List<UserModel> users = await _userRepositorio.BuscarTodosUsers();
            return Ok(users);
        }
        [HttpGet("table")]
        public async Task<ActionResult<List<UserDto>>> BuscarParaTabela()
        {
            List<UserModel> users = await _userRepositorio.BuscarParaTabela();
            List<UserDto> usersDto = users.Select(u => new UserDto
            {
                Id = u.Id,
                Nome = u.Nome,
                CPF = u.CPF,
                UserName = u.UserName,
                Telefone = u.Telefone,
                Status = u.Status.GetDescription()
            }).ToList();
            /*    EmpresaId = u.EmpresaId,
                Company = u.Company != null ? new CompanyDto
                {
                    Id = u.Company.Id,
                    NomeFantasia = u.Company.NomeFantasia,
                    CNPJ = u.Company.CNPJ,
                    Cidade = u.Company.Cidade,
                    Telefone = u.Company.Telefone,
                    Capital = u.Company.Capital,
                    Status = u.Company.Status.GetDescription(),
                } : null
            }).ToList();*/

            return Ok(usersDto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId(int id)
        {
            UserModel user = await _userRepositorio.BuscarPorId(id);
            return Ok(user);
        }
        
        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel userModel)
        {
            UserModel user =  await _userRepositorio.Adicionar(userModel);
            return Ok(user);
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepositorio.Atualizar(userModel, id);
            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<UserModel>> Apagar(int id)
        {
            bool apagado = await _userRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
