﻿using ControleDespesa5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class MovimentosDRRepository : BaseRepository<MovimentosDR>, IMovimentosDRRepository
    {
        // Nessa clase devem estar as logicas que inserem, adicionam, ou removem informações no banco de dados.
        private readonly IHttpContextAccessor contextAccessor;

        //private readonly AplicationContext contexto;


        // Este construtor permite a injeção de dependencia
        public MovimentosDRRepository(AplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            //this.contexto = contexto;
            this.contextAccessor = contextAccessor;
        }

        public void Grava_MovDesp(MovimentosDR MovimentosDR)
        {
            contexto.Set<MovimentosDR>().Add(new MovimentosDR(MovimentosDR.Id_despesa, MovimentosDR.data_MovimentosDR, MovimentosDR.valor_des, MovimentosDR.desc_despesa));
            contexto.SaveChanges();
        }

        public List<MovimentosDR> Get_Movdespesa()
        {
            return contexto.Set<MovimentosDR>().ToList();
        }

        public List<MovimentosDR> GetConMovimentosDR(string DescDespesa)
        {
            

            if (!string.IsNullOrEmpty(DescDespesa))
            {
                //var MdId = GetPagDesp();

                return contexto.Set<MovimentosDR>()
                        .Where(m => m.desc_despesa.Contains(DescDespesa))
                        .ToList();
            }
            else
            {
                return contexto.Set<MovimentosDR>().ToList();

            }



            
        }
        //private int GetPagDesp()
        //{
         //   return contextAccessor.HttpContext.Session.GetInt32("MovimentosDRid");
        //}

    }
}
