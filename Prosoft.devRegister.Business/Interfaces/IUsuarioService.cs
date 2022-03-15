
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Business.Interfaces
{
    public interface IUsuarioService: IDisposable
    {
        List<Usuario> Listar();
    }
}
