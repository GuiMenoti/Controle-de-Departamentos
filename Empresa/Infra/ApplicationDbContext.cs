using Empresa.Models;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Infra;

public class ApplicationDbContext : DbContext
{
    public DbSet<Departamento> Departamento { get; set; }
    public DbSet<Funcionario> Funcionario { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }  
}
