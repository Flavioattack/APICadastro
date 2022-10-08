using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace APIProjetoUpd8.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o CPF do cliente")]
        public Int64 Cpf { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione a data de nascimento do cliente")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Escolha o sexo do cliente")]
        public char Sexo { get; set; }
        [Required(ErrorMessage = "Digite o endereço do cliente")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Selecione o estado do cliente")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Selecione a cidade do cliente")]
        public string Cidade { get; set; }
    }
}
