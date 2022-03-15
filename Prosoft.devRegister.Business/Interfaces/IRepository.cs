
namespace Prosoft.devRegister.Business.Interfaces
{
    public interface IRepository<T>: IDisposable
    {
        List<T> ObterTodos();
    }
}
