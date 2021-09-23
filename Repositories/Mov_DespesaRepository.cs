using ControleDespesa5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class Mov_DespesaRepository : BaseRepository<Mov_Despesa>, IMov_DespesaRepository
    {
        // Nessa clase devem estar as logicas que inserem, adicionam, ou removem informações no banco de dados.
        private readonly IHttpContextAccessor contextAccessor;

        //private readonly AplicationContext contexto;


        // Este construtor permite a injeção de dependencia
        public Mov_DespesaRepository(AplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            //this.contexto = contexto;
            this.contextAccessor = contextAccessor;
        }

        public void Grava_MovDesp(Mov_Despesa mov_Despesa)
        {
            contexto.Set<Mov_Despesa>().Add(new Mov_Despesa(mov_Despesa.Id_despesa, mov_Despesa.data_mov_despesa, mov_Despesa.valor_des, mov_Despesa.desc_despesa));
            contexto.SaveChanges();
        }

        public List<Mov_Despesa> Get_Movdespesa()
        {
            return contexto.Set<Mov_Despesa>().ToList();
        }

        public List<Mov_Despesa> GetConMov_Despesa(string DescDespesa)
        {
            

            if (!string.IsNullOrEmpty(DescDespesa))
            {
                //var MdId = GetPagDesp();

                return contexto.Set<Mov_Despesa>()
                        .Where(m => m.desc_despesa.Contains(DescDespesa))
                        .ToList();
            }
            else
            {
                return contexto.Set<Mov_Despesa>().ToList();

            }



            
        }
        //private int GetPagDesp()
        //{
         //   return contextAccessor.HttpContext.Session.GetInt32("Mov_despesaid");
        //}

    }
}
