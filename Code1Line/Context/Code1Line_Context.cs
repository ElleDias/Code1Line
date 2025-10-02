using Code1Line.Domains;

using Microsoft.EntityFrameworkCore;

namespace Code1Line.Context
{
    public class Code1Line_Context : DbContext
    {
        public Code1Line_Context(DbContextOptions<Code1Line_Context> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Metrica> Metrica { get; set; }
        public DbSet<Atividades> Atividades { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }

        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Departamento> Departamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=NOTE16-S28\\SQLEXPRESS;Database=ProjetoC1LDB;User Id=sa;Pwd=Senai@134;TrustServerCertificate=true;");
            }
        }
    }
}
