using System.Collections.Generic;
using Code1Line.Domains;
using Microsoft.EntityFrameworkCore;

namespace Code1Line.Context
{
    public class Code1Line_Context : DbContext
    {
        public Code1Line_Context()
        {

        }

        public Code1Line_Context(DbContextOptions<Code1Line_Context> options) : base(options)
        {

        }

        /// <summary>
        /// Define que as classes se transformarão em tabelas no BD!
        /// </summary>
       
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Metrica> Metrica { get; set; }
        public DbSet<Atividades> Atividades { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }
     
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server= NOTE16-S28\\SQLEXPRESS; Database = Code1Line; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true; ");
            }
        }
    }
}
