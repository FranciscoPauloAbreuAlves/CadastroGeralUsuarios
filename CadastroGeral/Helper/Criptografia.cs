using System.Security.Cryptography;
using System.Text;

namespace CadastroGeral.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexo = new StringBuilder();
            
            foreach (var item in array)
            {
                strHexo.Append(item.ToString("x2"));
            }
            return strHexo.ToString();
        }
    }
}
