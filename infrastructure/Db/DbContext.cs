using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.infrastructure.Db;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuraçãoAppSetting;
    public DbContexto(IConfiguration configuraçãoAppSetting)
    {
        _configuraçãoAppSetting = configuraçãoAppSetting;
    }
    public DbSet<Adm> Adms { get; set; } = default!;

    public DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adm>().HasData(
            new Adm
            {
                Id = 1,
                Email = "adm@teste.com",
                Senha = "1234",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var stringConexao = _configuraçãoAppSetting.GetConnectionString("MySql")?.ToString();
            if (!string.IsNullOrEmpty(stringConexao))
            {
                optionsBuilder.UseMySql(
                stringConexao,
                ServerVersion.AutoDetect(stringConexao));
            }
        }

    }
}