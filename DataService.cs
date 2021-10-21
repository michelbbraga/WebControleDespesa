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
        private readonly IMovimentosDRRepository MovimentosDRRepository;
        private readonly IDespesaRepository despesarepository;
        private readonly IReceitaRepository receitarepository;
        private readonly IUsuarioRespository usuariorespository;

        public DataService(AplicationContext context, IMovimentosDRRepository MovimentosDRRepository, IDespesaRepository despesarepository,
            IReceitaRepository receitarepository)
        {
            this.context = context;
            this.MovimentosDRRepository = MovimentosDRRepository;
            this.despesarepository = despesarepository;
            this.receitarepository = receitarepository;
            this.usuariorespository = usuariorespository;



        }

        public void InicializaDB()
        {
            context.Database.EnsureCreated();
            //MovimentosDRRepository.Grava_MovDesp(MovimentosDR MovimentosDR);
        }
    }
}
