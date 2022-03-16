using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> Listar()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public async Task<Usuario> ObterUsuarioPorId(string usuarioId)
        {
            if (usuarioId == null) return null;

            return await _usuarioRepository.ObterUsuarioPorIdRepository(usuarioId);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}