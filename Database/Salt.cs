using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Treinamento.Database
{
    [Table("SALTS")]
    public class Salt
    {
        public int SaltId {get;set;}
        
        [Required]
        public byte[] SaltUser {get;set;}
        
        public virtual Users Users {get;set;}
    }
}