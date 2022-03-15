using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioservice;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioService usuarioservice, IUsuarioRepository usuarioRepository)
        {
            _usuarioservice = usuarioservice;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("listarUsuarios")]
        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await _usuarioRepository.ObterTodos();

        }
    }
}