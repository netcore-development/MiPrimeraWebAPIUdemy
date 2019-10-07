using Microsoft.EntityFrameworkCore;
using primerWebAPIVSCode.Models;

namespace primerWebAPIVSCode.Data
{
    public class DbContextPostgreSQL : DbContext
    {
        public DbContextPostgreSQL(DbContextOptions<DbContextPostgreSQL>options) : base(options) {}
        
        public DbSet<Autor> Autores {get;set;}
    }
}