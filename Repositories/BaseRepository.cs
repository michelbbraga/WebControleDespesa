using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ControleDespesa5.Models
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly AplicationContext contexto;
        protected readonly DbSet<T> dbset;

        public BaseRepository(AplicationContext contexto)
        {
            this.contexto = contexto;
            dbset = contexto.Set<T>();
        }
    }
}
