using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDespesa5.Models
{
    public class Usuarios : BaseModel
    {
        public Usuarios()
        {
        }
        [Required]
        [StringLength(45)]
        public string Nome_Usuario { get; set; }
        [StringLength(100)]
        public string Sobrenome { get; set; }
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string Senha { get; set; }

        public int Perfil { get; set; }
        

    }
}
