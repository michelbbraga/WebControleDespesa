using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDespesa5.Models;
using ControleDespesa5.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ControleDespesa5.Models
{
    public class ControlefModelView
    {
        public int Id { get; set; }
        public int Id_mv_despesa { get; set; }
        public DateTime data_mov_despesa { get; set; }
        public decimal valor_des { get; set; }
        public string desc_despesa { get; set; }
        public int Iddespesa { get; set; }
        public string Nomedespesa { get; set; }

        public List<Mov_Despesa> mov_Despesas { get; set; }

        public List<Despesa> Depesas { get; set; }

    }
}
