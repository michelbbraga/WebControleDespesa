using ControleDespesa5.Models;
using System.Collections.Generic;

namespace ControleDespesa5.Repositories
{
    public interface IDespesaRepository
    {
        void Grava_Despesa(Despesa desp);
        List<Despesa> GetDespesas();
    }
}