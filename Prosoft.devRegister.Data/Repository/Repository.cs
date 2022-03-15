using Prosoft.devRegister.Business.Interfaces;

namespace Prosoft.devRegister.Data.Repository
{
    public class Repository<T> : IRepository<T>
    {
       
        public List<T> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
