namespace FrontUpd8.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public Int64 Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
