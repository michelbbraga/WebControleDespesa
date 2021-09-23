using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesa5.Models;
using ControleDespesa5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControleDespesa5.Controllers
{
    public class FinanceiroController : Controller
    {
        private readonly AplicationContext contexto;
        private readonly IMov_DespesaRepository mov_desprepository;
        private readonly IDespesaRepository despesarepository;
        private readonly IReceitaRepository receitarepository;
        

        public FinanceiroController(AplicationContext contexto, IMov_DespesaRepository mov_desprepository,
            IDespesaRepository despesarepository, IReceitaRepository receitarepository)
        {
            this.contexto = contexto;
            this.mov_desprepository = mov_desprepository;
            this.despesarepository = despesarepository;
            this.receitarepository = receitarepository;

        }
        public IActionResult LMov_receita()
        {
            ViewBag.ltdesp = despesarepository.GetDespesas();
            return View("LMov_receita");
        }
        public IActionResult Ldespesa()
        {
            ViewBag.ltdesp = despesarepository.GetDespesas();
            return View("Ldespesa");
        }

        public IActionResult LReceita()
        {
            ViewBag.lreceita = receitarepository.GetReceita();
            return View("Lreceita");
            //return View(receitarepository.GetReceita());
        }

        public IActionResult CMov_receita()
        {
           
            return View(mov_desprepository.Get_Movdespesa());
        }

        [HttpGet]
        public IActionResult CfiltroMov_rec(string PesquisaDespesa)
        {
            ViewBag.ltdesp = mov_desprepository.GetConMov_Despesa(PesquisaDespesa);
            return View(mov_desprepository.GetConMov_Despesa(PesquisaDespesa));
        }



        [HttpPost]
        public void Criar(int id, [Bind("Id_despesa,data_mov_despesa,valor_des,desc_despesa,")] Mov_Despesa mov_Despesa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mov_desprepository.Grava_MovDesp(mov_Despesa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public void Cria_Despesa(int id, [Bind("Nomedespesa")] Despesa ldespesa)
        {
            if (ModelState.IsValid)
                try
                {
                    despesarepository.Grava_Despesa(ldespesa);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
        }

        [HttpPost]
        public void Cria_Receita(int i, [Bind("nomereceita")]Receita lreceita)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    receitarepository.Grava_Receita(lreceita);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }            
            }
        }
        [HttpPost]
        public void ConsultarMR()
        {
            
        }
    }
}
