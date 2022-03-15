using Microsoft.EntityFrameworkCore;
using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Data.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
