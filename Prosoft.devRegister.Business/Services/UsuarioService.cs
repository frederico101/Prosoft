using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Business
{
    public class Usuarioservice : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public Usuarioservice(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public List<Usuario> Listar()=> 
            _usuarioRepository.ObterTodos();
        

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}