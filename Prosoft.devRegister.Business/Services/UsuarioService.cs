using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;
using Prosoft.devRegister.Business.Validacoes;

namespace Prosoft.devRegister.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<Usuario> InserirUsuarioServices(Usuario usuario)
        {
            return _usuarioRepository.InserirUsuarioRepository(usuario);
        }
   
        public async Task<List<Usuario>> ListarUsuariosServices()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public async Task<Usuario> ObterUsuarioPorIdServices(string usuarioId)
        {
            if (usuarioId == null) return null;
            return await _usuarioRepository.ObterUsuarioPorIdRepository(usuarioId);
        }

        public async Task<Usuario> AtualizarUsuarioPorIdServices(Usuario usuario, Usuario novosDadosUsuario)
        {
            return await _usuarioRepository.AtualizarUsuarioPorIdRepository(ValidaEAtualizaUsuario.AtualizaUsuario(usuario, novosDadosUsuario));
        }
        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }

        
    }
}