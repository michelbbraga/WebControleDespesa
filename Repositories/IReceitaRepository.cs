using ControleDespesa5.Models;
using System.Collections.Generic;

namespace ControleDespesa5.Repositories
{
    public interface IReceitaRepository
    {
        public List<Receita> GetReceita();
        void Grava_Receita(Receita treceita);
    }
}