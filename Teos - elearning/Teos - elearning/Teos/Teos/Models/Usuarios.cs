using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Teos.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        public string SobreNome { get; set; }
                
        public string Login { get; set; }

        public string Senha { get; set; }

        public int PapeisId { get; set; }

        public int? ClientesId { get; set; }
        //Criar usuários

        public virtual Papeis Papeis { get; set; }

        
       public virtual Clientes Clientes { get; set; }

        public virtual ICollection<Matriculas> Matriculas { get; set; }
    }
}