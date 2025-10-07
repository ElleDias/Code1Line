using Code1Line.Domains;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Context
{
    public class Code1Line_Context : DbContext
    {
        public Code1Line_Context(DbContextOptions<Code1Line_Context> options)
            : base(options) { }

        public DbSet<Acessos> Acessos { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }
        public DbSet<Metrica> Metrica { get; set; }
        public DbSet<Monitoramento> Monitoramento { get; set; }
        public DbSet<Outlier> Outlier { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioDepartamento> UsuarioDepartamento { get; set; }
        public DbSet<UsuarioEquipe> UsuarioEquipe { get; set; }
        public DbSet<UsuarioFuncao> UsuarioFuncao { get; set; }
    }
}
