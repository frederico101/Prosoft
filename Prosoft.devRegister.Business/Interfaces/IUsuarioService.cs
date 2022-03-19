
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Business.Interfaces
{
    public interface IUsuarioService: IDisposable
    {
        Task<List<Usuario>> ListarUsuariosServices();
        Task<Usuario> ObterUsuarioPorIdServices(string usuarioId);
        Task<Usuario> AtualizarUsuarioPorIdServices(Usuario usuarioId, Usuario novosDadosUsuario);
        Task<Usuario> InserirUsuarioServices(Usuario usuario);
    }
}
