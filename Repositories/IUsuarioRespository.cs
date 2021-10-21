using ControleDespesa5.Models;
using System.Collections.Generic;

namespace ControleDespesa5.Repositories
{
    public interface IUsuarioRespository
    {
        List<Usuarios> Busca_Usuario(string nomelogin);
    }
}