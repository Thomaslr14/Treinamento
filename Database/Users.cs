using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treinamento.Database
{
    [Table("USERS")]
    public class Users
    
    {
        public int UsersId {get;set;}
        
        [Required,MaxLength(50)] 
        public string Username {get;set;}

        [Required]
        public byte[] Password {get;set;}

        public int Salt_FK {get;set;}
        
        [ForeignKey("Salt_FK")]
        public virtual Salt Salt {get;set;}     

    }
}