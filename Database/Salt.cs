using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Treinamento.Database
{
    public class Salt
    {
        [Key()]
        public int SaltID {get;set;}
        
        [Required]
        public byte[] SaltUser {get;set;}
        public List<Users> Users {get;set;}
    }
}