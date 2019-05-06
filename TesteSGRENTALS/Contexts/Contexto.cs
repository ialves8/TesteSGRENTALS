using Microsoft.EntityFrameworkCore;
using TesteSGRENTALS.Entities;

namespace TesteSGRENTALS.Contexts
{
    public class Contexto : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }
    }
}
