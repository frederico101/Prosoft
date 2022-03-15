
using Newtonsoft.Json;

namespace Prosoft.devRegister.Business.Model
{
    public class Usuario
    {
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

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

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Avatar")]
        public string Avatar { get; set; }

        [JsonProperty("Squad")]
        public string Squad { get; set; }

        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTime CreatedAt { get; set; }
    }

}
