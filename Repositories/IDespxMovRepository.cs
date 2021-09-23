using ControleDespesa5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ControleDespesa5.Repositories
{
    public interface IDespxMovRepository
    {
        IList<Despesa> GetDespesas();
        public void Grava_MovDesp(Mov_Despesa mov_Despesa);
    }
}