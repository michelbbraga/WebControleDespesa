using ControleDespesa5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Repositories
{
    public class ReceitaRepository: BaseRepository<Receita> , IReceitaRepository
    {

        public ReceitaRepository(AplicationContext contexto) : base(contexto)
        {
        }

        public List<Receita> GetReceita()
        {
            return contexto.Set<Receita>().ToList();
        }
        public Receita Filtra_receira()
        {
            var flreceita = dbset.Where(r => r.Nomereceita == "").SingleOrDefault();
            return flreceita;

        }
        public void Grava_Receita(Receita treceita)
        {
            contexto.Set<Receita>().Add(new Receita(treceita.Nomereceita));
            contexto.SaveChanges();
        }


    }
}
