using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Treinamento.Database
{
    public class Salt
    {
        [Key()]
        public int Id {get;set;}
        
        [Required]
        public byte[] SaltUser {get;set;}
        public List<User> Users {get;set;}
    }
}