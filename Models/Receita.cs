using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Models
{
    public class Receita : BaseModel
    {
        public Receita()
        {
        }
        [Required]
        [StringLength(75)]
        public string Nomereceita {get; set;}
        public int Id_User { get; set; }


        public Receita(string nomereceita)
        {
            this.Nomereceita = Nomereceita;
        }
    }
}
