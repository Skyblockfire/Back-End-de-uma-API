using BackEnd.Models;

namespace BackEnd.Repositorios.Interfaces
{
    public interface IUserRepositorio
    {
        Task<List<UserModel>> BuscarTodosUsers();
        Task<List<UserModel>> BuscarParaTabela();
        Task<UserModel> BuscarPorId(int id);
        Task<UserModel> Adicionar(UserModel user);
        Task<UserModel> Atualizar(UserModel user, int id);
        Task<bool> Apagar(int id);
            
    }
}
