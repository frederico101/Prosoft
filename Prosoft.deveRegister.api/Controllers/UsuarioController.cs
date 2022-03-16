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
        private readonly ILogger<UsuariosController> _logger;
        public UsuariosController(IUsuarioService usuarioservice, IUsuarioRepository usuarioRepository, 
                                  ILogger<UsuariosController> logger)
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