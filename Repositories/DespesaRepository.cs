using ControleDespesa5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly AplicationContext contexto;

        public DespesaRepository(AplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public List<Despesa> GetDespesas()
        {
            return contexto.Set<Despesa>().ToList();
        }

        public void Grava_Despesa(Despesa desp)
        {
            contexto.Set<Despesa>().Add(new Despesa(desp.Nomedespesa));
            contexto.SaveChanges();
        }
    }
}
