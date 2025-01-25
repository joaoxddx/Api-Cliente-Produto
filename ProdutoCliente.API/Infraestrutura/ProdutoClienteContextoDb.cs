using Microsoft.EntityFrameworkCore;
using ProdutoCliente.API.Entidades;

namespace ProdutoCliente.API.Infraestrutura
{
    public class ProdutoClienteContextoDb : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\Projetos\\ProdutoCliente\\ProdutoClienteDB.db");
        }
    }
}
