using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Models
{
    public class Despesa : BaseModel
    {
        public Despesa()
        { 
        }
        
        [StringLength(75)]
        [Required]
        public string Nomedespesa { get; set; }
        public int Id_Usuario { get; set; }

        public virtual Usuarios Usuarios { get; set; }

        public Despesa(string Nomedesp)
        {            
            this.Nomedespesa = Nomedesp;
        }
        public Despesa(int Id, string Nomedesp)
        {
            this.Id = Id;
            this.Nomedespesa = Nomedesp;
        }
    }
    
}
