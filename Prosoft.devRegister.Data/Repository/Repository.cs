using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;
using Prosoft.devRegister.Data.Context;

namespace Prosoft.devRegister.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(AppDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        static readonly HttpClient client = new HttpClient();
        public async Task<List<TEntity>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ObterUsuarioPorIdRepository(string usuarioId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> AtualizarUsuarioPorIdRepository(Usuario usuario)
        {
              return null;
        }

        public Task<TEntity> InserirUsuarioRepository(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
