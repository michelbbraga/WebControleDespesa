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
    public class Mov_Despesa : BaseModel
    {
        public Mov_Despesa()
        {
        }

        [ForeignKey("Despesa")]
        public int Id_despesa { get; set; }
        public virtual Despesa Despesa { get; set; }
        [Required]
        public DateTime data_mov_despesa { get; set; }
        [Required]
        public decimal valor_des { get; set; }
        [Required]
        [StringLength (75)]
        public string desc_despesa { get; set; }

        public Mov_Despesa(int Id_despesa, DateTime data_mov_despesa, decimal valor_des, string desc_despesa)
        {
            this.Id_despesa = Id_despesa;
            this.data_mov_despesa = data_mov_despesa;
            this.valor_des = valor_des;
            this.desc_despesa = desc_despesa;
        }

        //public List<Mov_Despesa> MDespesa { get; private set; } = new List<Mov_Despesa>(); 
    }
}

