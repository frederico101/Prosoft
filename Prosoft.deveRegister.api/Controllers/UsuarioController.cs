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
            _logger = logger;
        }

        [HttpGet("listarUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuarios()
        {
            try
            {
                var result = await _usuarioRepository.ObterTodos();
                
                if (result == null) return BadRequest(new { success = false, data = "" });
                
                return Ok(new { success = true, data = result});
            }
            catch (Exception ex) {
                _logger.LogError($"Erro ao listar os usuarios => {ex}");
            }
            return NotFound(new { success = false, data = ""});
        }

        [HttpGet("obterUsuarioPorId")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(string usuarioId)
        {
            try
            {
                var user = _usuarioservice.ObterUsuarioPorId(usuarioId);
                var result = await _usuarioRepository.ObterUsuarioPorIdRepository(usuarioId);

                if (result == null) return BadRequest(new { success = false, data = "" });

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar os usuarios pelo id => {ex}");
            }
            return NotFound(new { success = false, data = "" });
        }

    }
}