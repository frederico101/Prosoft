using Prosoft.devRegister.Business.Model;

namespace Prosoft.devRegister.Business.Validacoes
{
    public static class ValidaEAtualizaUsuario
    {
        public static Usuario AtualizaUsuario(Usuario usuario, Usuario novosDadosUsuario) 
        {
            usuario.Name = novosDadosUsuario.Name != null ? novosDadosUsuario.Name : usuario.Name;
            usuario.Avatar = !string.IsNullOrEmpty(novosDadosUsuario.Avatar) ? novosDadosUsuario.Avatar : usuario.Avatar;
            usuario.Squad = !string.IsNullOrEmpty(novosDadosUsuario.Squad) ? novosDadosUsuario.Squad : usuario.Squad;
            usuario.Login = !string.IsNullOrEmpty(novosDadosUsuario.Login) ? novosDadosUsuario.Login : usuario.Login;
            usuario.Email = !string.IsNullOrEmpty(novosDadosUsuario.Email) ? novosDadosUsuario.Email : usuario.Email;

            return usuario;
        }
    }
}
