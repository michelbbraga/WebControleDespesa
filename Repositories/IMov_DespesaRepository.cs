using ControleDespesa5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ControleDespesa5.Repositories
{
    public interface IMovimentosDRRepository 
    {
        void Grava_MovDesp(MovimentosDR MovimentosDR);

        public List<MovimentosDR> GetConMovimentosDR(string DescDespesa);
        List<MovimentosDR> Get_Movdespesa();


    }
}