using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treinamento.Database
{
    [Table("USERS")]
    public class Users
    
    {
        [Key()]
        public int UsersID {get;set;}
        
        [Required,MaxLength(50)] 
        public string Username {get;set;}

        [Required]
        public byte[] Password {get;set;}  

        public int SaltID_FK {get;set;}

        [ForeignKey("SaltID_FK")]
        public Salt Salt {get;set;}

    }
}