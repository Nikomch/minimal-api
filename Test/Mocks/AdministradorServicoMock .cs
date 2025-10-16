using MinimalApi.Domain.Entities;
using minimal_api.infrastructure.Interfaces;
using MinimalApi.DTOs;

namespace Test.Mocks;

public class AdministradorServicoMock : IAdministradorServico
{
    private static List<Adm> administradores = new List<Adm>(){
        new Adm{
            Id = 1,
            Email = "adm@teste.com",
            Senha = "123456",
            Perfil = "Adm"
        },
        new Adm{
            Id = 2,
            Email = "editor@teste.com",
            Senha = "123456",
            Perfil = "Editor"
        }
    };

    public Adm? BuscaPorId(int id)
    {
        return administradores.Find(a => a.Id == id);
    }

    public Adm Incluir(Adm administrador)
    {
        administrador.Id = administradores.Count() + 1;
        administradores.Add(administrador);

        return administrador;
    }

    public Adm? Login(LoginDTO loginDTO)
    {
        return administradores.Find(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    public List<Adm> Todos(int? pagina)
    {
        return administradores;
    }
}