using System;
using System.Text;
using System.Security.Cryptography;
using Treinamento.Database;

namespace Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {

          //  var connect = new DatabaseConnection();

            string senha = "1";
            while (senha != "0")
            {
            Console.WriteLine("Qual a senha que deseja encriptar? ");
            senha = Console.ReadLine();
            var hash = Hash.GenerateHash(senha);
            var salt = Salt.GenerateSalt();
            var encrypt = Program.JoinHashSalt(salt, hash);
            Console.WriteLine($"SENHA: {Convert.ToBase64String(hash)}");
            Console.WriteLine($"SALT: {Convert.ToBase64String(salt)}");
            Console.WriteLine($"ENCRYPT FINAL: {Convert.ToBase64String(encrypt)}");
            }
        }

        static byte[] JoinHashSalt(byte[] salt, byte[] hash) 
        {
            string SaltString = Convert.ToBase64String(salt);
            string HashString = Convert.ToBase64String(hash);
            byte[] overall = Encoding.ASCII.GetBytes(SaltString + HashString);
            
            byte[] encrypt = SHA512.Create().ComputeHash(overall);
            return encrypt;
        }


        class Hash
        {
            public static byte[] GenerateHash(string senha)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(senha);
                byte[] hash = SHA512.Create().ComputeHash(bytes);
                return hash;

            }
        }
        class Salt
        {            
            public static byte[] GenerateSalt()
            {
                using (RNGCryptoServiceProvider random = new RNGCryptoServiceProvider())
                {
                    byte[] tamanho = new byte[128];
                    random.GetNonZeroBytes(tamanho);
                    return tamanho;
                }

            }
        }

        
    }
}
  