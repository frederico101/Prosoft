using Microsoft.AspNetCore.Mvc;
using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;
using Prosoft.devRegister.Business.Validacoes;
using System.Web.Http.Description;

namespace Prosoft.devRegister.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioservice;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUsuarioService usuarioservice, IUsuarioRepository usuarioRepository, 
                                  ILogger<UsuarioController> logger)
        {
            _usuarioservice = usuarioservice;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("inserirUsuario")]
        public async Task<ActionResult> inserirUsuario(Usuario usuario)
        {
            try
              {
                
                if (!EmailValidation.ValidaEmail(usuario.Email)) return BadRequest(new { success = false, data = "Dominio de email inválido, apenas usuários com domino de email @prosoft.com.br são permitidos" });
                
                var result = await _usuarioRepository.InserirUsuarioRepository(usuario);

                if (string.IsNullOrEmpty(result.Id)) return BadRequest(new { success = false, data = "" });
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao inserir usuarios => {ex}");
            }
            return NotFound(new { success = false, data = "" });
        }


        [HttpGet("listarUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuarios()
        {
            try
            {
                var result = await _usuarioRepository.ObterTodos();
                
                if (result.Count <= 0) return BadRequest(new { success = false, data = "" });
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
                var result = await _usuarioservice.ObterUsuarioPorIdServices(usuarioId);

                if (result == null) return BadRequest(new { success = false, data = "" });
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar os usuarios pelo id => {ex}");
            }
            return NotFound(new { success = false, data = "" });
        }

        [HttpPost]
        [Route("atualizarUsuarioPorId")]
        [ResponseType(typeof(Usuario))]
        public async Task<ActionResult<Usuario>> AtualizarUsuarioPorId([FromBody] Usuario novosDadosUsuario)
        {
            try { 

            var resultUsuario = await _usuarioservice.ObterUsuarioPorIdServices(novosDadosUsuario.Id);
          
            var result = await _usuarioservice.AtualizarUsuarioPorIdServices(resultUsuario, novosDadosUsuario);

            if (string.IsNullOrEmpty(result.Id)) return BadRequest(new { success = false, data = "" });

            return Ok(new { success = true, data = result });
        }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar usuario => {ex}");
            }
            return NotFound(new { success = false, data = "" });
         }

        [HttpPost]
        [Route("atualizarEmail")]
        [ResponseType(typeof(Usuario))]
        public async Task<ActionResult<Usuario>> AtualizarEmail()
        {
            try
            {
                
                Usuario result = new Usuario();
                var results = await _usuarioRepository.ObterTodos();

                var emails = EmailValidation.AtualizaEmail(results);
                if (emails.Count <= 0) return NotFound(new { success = true, data = "Todos os dominios de emails estão atualizados" });
                foreach (var emailCorrigido in emails) { 

                   var worngEmail = await _usuarioservice.ObterUsuarioPorIdServices(emailCorrigido.Id);
                        if(worngEmail.Id == emailCorrigido.Id)
                        {
                            worngEmail.Email = emailCorrigido.Email;
                       
                            result = await _usuarioservice.AtualizarUsuarioPorIdServices(worngEmail, emailCorrigido);
                        }
                    }
                
                if (result == null) return BadRequest(new { success = false, data = "" });

                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar o dominio de email => {ex}");
            }
            return NotFound(new { success = false, data = "" });
        }
    }
}