using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ControleDespesa5.Models
{
    public abstract class  BaseModel
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key()]
        public int Id  { get; set;}        
    }
    public class MovimentosDR : BaseModel
    {
        public MovimentosDR()
        {
        }

        [ForeignKey("Despesa")]
        public int Id_Usario { get; set; }
        public int Id_Despesa { get; set; }
        public int Id_Receita { get; set; }
        public virtual Despesa Despesa { get; set; }
        [Required]
        public DateTime Data_MovimentosDR { get; set; }
        [Required]
        public decimal Valor_Des { get; set; }
        [Required]
        [StringLength (75)]
        public string Desc_Despesa { get; set; }
        public bool Repete { get; set; }

        public int Duracao { get; set; }

        public MovimentosDR(int Id_Usuario, int Id_Despesa, int Id_Receita, 
                            DateTime Data_MovimentosDR, decimal Valor_Des, string Desc_Despesa, bool Repete, int Duracao)
        {
            this.Id_Usario = Id_Usario;
            this.Id_Despesa = Id_Despesa;
            this.Data_MovimentosDR = Data_MovimentosDR;
            this.Valor_Des = Valor_Des;
            this.Desc_Despesa = Desc_Despesa;
        }

        //public List<MovimentosDR> MDespesa { get; private set; } = new List<MovimentosDR>(); 
    }
}

