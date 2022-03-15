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

            HttpResponseMessage response = await client.GetAsync("https://61a170e06c3b400017e69d00.mockapi.io/DevTest/Dev");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<TEntity>>(responseBody);
            return result;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
