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

        public Usuarios Busca_Usuario(string nomelogin, string Senha)
        {
            var FcUsuarios = dbset.Where(u => u.Login == nomelogin &&
                                         u.Senha == Senha).SingleOrDefault();
            return FcUsuarios;

                //var fcreceita = (from b in contexto.usuarios
                //where b.login.contains(login) &&
                //b.senha.contains(senha)
                //select b).tolist();

        }
    }
}
