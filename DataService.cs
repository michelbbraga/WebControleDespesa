using ControleDespesa5.Models;
using ControleDespesa5.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Http;

namespace ControleDespesa5
{
    public class DataService : IDataService
    {
        private readonly AplicationContext context;
        private readonly HttpContextAccessor contextAccessor;
        private readonly IMov_DespesaRepository mov_DespesaRepository;
        private readonly IDespesaRepository despesarepository;
        private readonly IReceitaRepository receitarepository;
        
        public DataService(AplicationContext context, IMov_DespesaRepository mov_DespesaRepository, IDespesaRepository despesarepository,
            IReceitaRepository receitarepository)
        {
            this.context = context;
            this.mov_DespesaRepository = mov_DespesaRepository;
            this.despesarepository = despesarepository;
            this.receitarepository = receitarepository;



        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();
            //mov_DespesaRepository.Grava_MovDesp(Mov_Despesa mov_Despesa);
        }
    }
}
