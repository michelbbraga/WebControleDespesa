using ControleDespesa5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class UsuarioRespository : IUsuarioRespository
    {
        private readonly AplicationContext contexto;

        public UsuarioRespository(AplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Usuarios> Busca_Usuario(string nomelogin)
        {
            if (!string.IsNullOrEmpty(nomelogin))
            {
                return contexto.Set<Usuarios>()
                    .Where(p => p.Login.Contains(nomelogin))
                    .ToList();
            }
            else
            {
                return contexto.Set<Usuarios>().ToList();
            }
        }
    }
}
