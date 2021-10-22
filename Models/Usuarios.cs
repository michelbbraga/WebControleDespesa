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

        public Usuarios(string Nome_Usuario, string Sobrenome, string Login, string Email, string Senha, int Perfil)
        {
            this.Nome_Usuario = Nome_Usuario;
            this.Sobrenome = Sobrenome;
            this.Login = Login;
            this.Email = Email;
            this.Senha = Senha;
            this.Perfil = Perfil;
        }

        public Usuarios(string Login, string Senha)
        {
            this.Login = Login;
            this.Senha = Senha;
        }

    }

}
