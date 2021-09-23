using ControleDespesa5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class DespxMovRepository : IDespxMovRepository
    {
        private readonly AplicationContext contexto;

        public DespxMovRepository(AplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Despesa> GetDespesas()
        {
            return contexto.Set<Despesa>().ToList();
        }
        public void Grava_MovDesp(Mov_Despesa mov_Despesa)
        {
            contexto.Set<Mov_Despesa>().Add(new Mov_Despesa(mov_Despesa.Id_despesa, mov_Despesa.data_mov_despesa, mov_Despesa.valor_des, mov_Despesa.desc_despesa));
            contexto.SaveChanges();
        }
    }
}
