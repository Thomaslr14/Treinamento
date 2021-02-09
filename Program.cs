using System;
using System.Text;
using System.Security.Cryptography;

namespace Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {
           /* for (int i = 0; i < 99999; i++)
            {
                Console.WriteLine("ME LIGAAAA !!!!!");
            } */
            string senha = "1";
            while (senha != "0")
            {
            Console.WriteLine("Qual a senha que deseja encriptar? ");
            senha = Console.ReadLine();
            Console.WriteLine(Convert.ToBase64String(Hash.GenerateHash(senha)));
            }

            
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
                var tamanho = new byte[32];
                byte[] salt = RandomNumberGenerator.Create().GetNonZeroBytes(tamanho);

            }
        }
    }
}
  