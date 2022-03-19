using Newtonsoft.Json;
using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;
using Prosoft.devRegister.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Prosoft.devRegister.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository //,Repository<Usuario>
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
      
        public async Task<Usuario> ObterUsuarioPorIdRepository(string usuarioId)
        {
            string baseUrl = $"https://61a170e06c3b400017e69d00.mockapi.io/DevTest/Dev/{usuarioId}";
            HttpResponseMessage response = await client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<Usuario>(responseBody);
            return result;

        }

        public async Task<Usuario> AtualizarUsuarioPorIdRepository(Usuario usuario)
        {
            string baseUrl = $"https://61a170e06c3b400017e69d00.mockapi.io/DevTest/Dev/{usuario.Id}";
            HttpResponseMessage response = await client.PutAsJsonAsync(baseUrl, usuario);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Usuario>(responseBody);
            return result;
        }

        public async Task<Usuario> InserirUsuarioRepository(Usuario usuario)
        {
            try { 
            
            string baseUrl = $"https://61a170e06c3b400017e69d00.mockapi.io/DevTest/Dev/";
             client.DefaultRequestHeaders.Accept.Clear();
             client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.PostAsJsonAsync(baseUrl, usuario);
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Usuario>(responseBody);
            return result;
            }
            catch (HttpRequestException e) {

                throw new HttpRequestException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
