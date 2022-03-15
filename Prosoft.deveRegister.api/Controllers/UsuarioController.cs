using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {

        [HttpGet("listar")]
        public IEnumerable<Usuario> Listar()
        {
            return null;
        }
    }
}