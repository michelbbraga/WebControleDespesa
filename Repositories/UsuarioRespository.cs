using ControleDespesa5.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class UsuarioRespository : BaseRepository<Usuarios>, IUsuarioRespository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public UsuarioRespository(AplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            //this.contexto = contexto;
            this.contextAccessor = contextAccessor;
        }

        public List<Usuarios> Busca_Usuario(string nomelogin, string senha)
        {
            if (!string.IsNullOrEmpty(nomelogin))
            {
                var result = (from b in contexto.Usuarios
                where b.Login.Contains(nomelogin) &&
                b.Senha.Contains(senha)
                select b).ToList();

                return result;
            }
            else
            {
                return contexto.Set<Usuarios>().ToList();
            }
        }
    }
}
