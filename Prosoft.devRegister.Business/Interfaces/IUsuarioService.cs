
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Business.Interfaces
{
    public interface IUsuarioService: IDisposable
    {
        Task<List<Usuario>> Listar();
        Task<Usuario> ObterUsuarioPorId(string usuarioId);
    }
}
