using System;
using System.Text;
using System.Security.Cryptography;
using Treinamento.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Treinamento
{
    class Program
    {
        static void Main(string[] args)
        {

            string password = "1";
            while (password != "0")
            {
                
                
                    using(DatabaseConnection db = new DatabaseConnection())
                    {
                        Users u = new Users();
                        Salt s = new Salt();
                        

                        Console.WriteLine("Informe um usuário:");
                        var username = Console.ReadLine();
                        
                        Console.WriteLine("Informe uma senha: ");
                        password = Console.ReadLine();
                
                        var salt = Salt.GenerateSalt();

                        var encrypt = Program.JoinHashSalt(salt, Hash.GenerateHash(password));
                        
                        u.Username = username;
                        u.Password = encrypt;
                        u.SaltID_FK = 1;
                        u.Salt.SaltID = 1;
                        u.Salt.SaltUser = salt;

                        db.Add(u);
                        db.SaveChanges();


                        // Console.WriteLine($"SENHA: {Convert.ToBase64String(hash)}");
                        // Console.WriteLine($"SALT: {Convert.ToBase64String(salt)}");
                        // Console.WriteLine($"ENCRYPT FINAL: {Convert.ToBase64String(encrypt)}");
                    }
               
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
  