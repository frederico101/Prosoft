using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Business.Model;
using System.Text.RegularExpressions;

namespace Prosoft.devRegister.Business.Validacoes
{
    public static class EmailValidation
    {
        public static IList<Usuario> AtualizaEmail(List<Usuario> usuarios)
        {
            var user = new Usuario();
            List<Usuario> emailsParaAtualizar = new List<Usuario>();
            var wrongEmailsDomains = usuarios.Where(u => !u.Email.Contains("@prosoft.com.br")).ToList();

            if (wrongEmailsDomains != null)
            {
                foreach (Usuario item in wrongEmailsDomains)
                {
                    var splitedEmail = item.Email.Split('@')[0];
                    item.Email = splitedEmail + "@prosoft.com.br";
                    emailsParaAtualizar.Add(item);
                }
            }
            return emailsParaAtualizar;

        }

        public static bool ValidaEmail(string email)
        {
            string pattern = "[A-Za-z0-9._%+-]+@prosoft.com.br$";
            Regex rg = new Regex(pattern);
            return rg.IsMatch(email);
        }
    }
}
