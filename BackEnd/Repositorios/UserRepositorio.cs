using BackEnd.Data;
using BackEnd.Models;
using BackEnd.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly BackEndDBContext _dbContext;
        public UserRepositorio(BackEndDBContext backEndDBContext) 
        {
            _dbContext = backEndDBContext;
        }
        public async Task<UserModel> BuscarPorId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> BuscarTodosUsers()
        {
            return await _dbContext.Users
                .Include(u => u.Company)
                .ToListAsync();
        }
        public async Task<List<UserModel>> BuscarParaTabela()
        {
            return await _dbContext.Users
                .Include(u => u.Company)
                .ToListAsync();
        }
        public async Task<UserModel> Adicionar(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> Atualizar(UserModel user, int id)
        {
            UserModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.UserName = user.UserName;
            usuarioPorId.Nome = user.Nome;
            usuarioPorId.Telefone = user.Telefone;
            usuarioPorId.CPF = user.CPF;
            usuarioPorId.Status = user.Status;
            usuarioPorId.EmpresaId = user.EmpresaId;

            _dbContext.Users.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            UserModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }
            
            _dbContext.Users.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        

    }
}
