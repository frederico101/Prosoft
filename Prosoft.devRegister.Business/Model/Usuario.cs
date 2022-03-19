
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Prosoft.devRegister.Business.Model
{
    public class Usuario: Entity
    {
        //public Usuario(string id,  DateTime createdAt, string name, string avatar, string squad, string login, string email )
        //{ 

        //    Id = id;
        //    CreatedAt = createdAt;
        //    Name = name;
        //    Avatar = avatar;    
        //    Squad = squad;
        //    Login = login;
        //    Email = email;
        //}
        //CreatedAt = createdAt;
        //    Name = name;
      

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("squad")]
        public string Squad { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }


      

        //private string SetName(string name)
        //{
        //    if (string.IsNullOrEmpty(name)) return null;
        //    Name = name;
        //    return Name;
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
