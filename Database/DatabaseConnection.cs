using Microsoft.EntityFrameworkCore;


namespace Treinamento.Database
{
    public class DatabaseConnection : DbContext
    {
        DbSet<Users> Users {get;set;}

        DbSet<Salt> Salts {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {   
            optionsBuilder.UseSqlServer(@"Server=NTBHMDC090747;Database=master;Trusted_Connection=True;MultipleActiveResultSets=true");
            
        }
        
    }
}