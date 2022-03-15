using Newtonsoft.Json;
using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;
using Prosoft.devRegister.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosoft.devRegister.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository //Repository<Usuario>,
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<List<Usuario>> ObterTodos()
        {
            HttpResponseMessage response = await client.GetAsync("https://61a170e06c3b400017e69d00.mockapi.io/DevTest/Dev");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<Usuario>>(responseBody);
            return result;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
