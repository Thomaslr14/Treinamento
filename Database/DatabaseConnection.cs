using Microsoft.EntityFrameworkCore;


namespace Treinamento.Database
{
    public class DatabaseConnection : DbContext
    {
        const string _connectionString = "Server=TLR073354;Database=TESTE_DB;Trusted_Connection=True;MultipleActiveResultSets=true";
        
        
        public DbSet<Users> Users {get;set;}
        public DbSet<Salt> Salt {get;set;}
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(_connectionString);
        }
        
    }
}