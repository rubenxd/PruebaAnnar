using HospitalApi.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<tbl_paciente> tbl_paciente { get; set; }
        public DbSet<tbl_tipo_documento> tbl_tipo_documento { get; set; }
        public DbSet<tbl_genero> tbl_genero { get; set; }
        public DbSet<tbl_estado> tbl_estado { get; set; }
    }
}
