using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domain.DTOs;
using MinimalApi.Domain.Entities;
using MinimalApi.DTOs;

namespace minimal_api.infrastructure.Interfaces
{
    public interface IAdministradorServico
    {
        Adm? Login(LoginDTO loginDTO);
        Adm Incluir(Adm adm);
        Adm? BuscaPorId(int id);
        List<Adm> Todos(int? pagina);

    }
}