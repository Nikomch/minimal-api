using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.DTOs;
using minimal_api.infrastructure.Interfaces;
using MinimalApi.Domain.Entities;
using MinimalApi.DTOs;
using MinimalApi.infrastructure.Db;

namespace MinimalApi.Domain.Services;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    public Adm? BuscaPorId(int id)
    {
        return _contexto.Adms.Where(v => v.Id == id).FirstOrDefault();
    }

    public Adm Incluir(Adm adm)
    {
        _contexto.Adms.Add(adm);
        _contexto.SaveChanges();

        return adm;
    }

    public Adm? Login(LoginDTO loginDTO)
    {
        var adm = _contexto.Adms.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
        return adm;
    }

    public List<Adm> Todos(int? pagina)
    {
        var query = _contexto.Adms.AsQueryable();

        int itensPorPagina = 10;

        if (pagina!= null){
            query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
        }
        return query.ToList();
    }
}