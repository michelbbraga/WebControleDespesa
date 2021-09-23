using ControleDespesa5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ControleDespesa5.Repositories
{
    public interface IMov_DespesaRepository 
    {
        void Grava_MovDesp(Mov_Despesa mov_Despesa);

        public List<Mov_Despesa> GetConMov_Despesa(string DescDespesa);
        List<Mov_Despesa> Get_Movdespesa();


    }
}