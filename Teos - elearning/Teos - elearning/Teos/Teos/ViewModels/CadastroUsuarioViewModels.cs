using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teos.ViewModels
{
    public class CadastroUsuarioViewModels
    {

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [DisplayName("Sobrenome")]
        public string SobreNome { get; set; }

        [DisplayName("E-mail: (Use seu principal pois ele será seu login!)")]
        [Required(ErrorMessage = "Login é obrigatório")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Seu login deve ser um e-mail válido")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Sua senha tem que ter no mínimo 6 caracteres")]
        [RegularExpression(@"^[a-zA-Z][0-9A-Za-z@!#$%¨&*()_><?/}{§|\.]*\d+[0-9A-Za-z@!#$%¨&*()_><?/}{§|\.]*$", 
            ErrorMessage ="Sua senha deve ter caracteres e números")]       
        public string Senha { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        [Compare(nameof(Senha), ErrorMessage ="As senhas devem ser as mesmas")]
        [DisplayName("Confirmar Senha")]
        public string ConfirmarSenha { get; set; }



    }
}