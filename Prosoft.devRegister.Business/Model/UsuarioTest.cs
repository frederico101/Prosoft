
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prosoft.devRegister.Business.Model
{
    public class UsuarioTest: Entity
    {
        //public Usuario(){}
        //public Usuario(string nome ){

        //    SetName(nome);
        //}
        [Key]
        [JsonProperty("id")]
        public string Id { get; set; }

        //[JsonProperty("createdAt")]
        //public DateTime CreatedAt { get; private set; }

        //[JsonProperty("name")]
        //public string Name { get; private set; }

        //[JsonProperty("avatar")]
        //public string Avatar { get; private set; }

        //[JsonProperty("squad")]
        //public string Squad { get; private set; }

        //[JsonProperty("login")]
        //public string Login { get; private set; }

        //[JsonProperty("email")]
        //public string Email { get; private set; }

        //private void SetName(string name) {
        //    if (string.IsNullOrEmpty(name)) return;
        //        Name = name;
        //}

        //private void SetAvatar(string avatar) {
        //    if (string.IsNullOrEmpty(avatar)) return;
        //    Avatar = avatar;
        //}
        //private void SetSquad(string squad)
        //{
        //    if (string.IsNullOrEmpty(squad)) return;
        //    Squad = squad;
        //}

        //private void SetLogin(string login)
        //{
        //    if (string.IsNullOrEmpty(login)) return;
        //    Login = login;

        //}
        //private void SetEmail(string email) 
        //{
        //    if (string.IsNullOrEmpty(email)) return;
        //    Email = email;
        //}
    }

}
