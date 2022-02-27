namespace Minimal.Api.Models
{
    public record User
    {
        public User()
        {

        }
        public User(Guid id, string nome, DateTime dataCriacao)
        {
            Id = id;    
            Nome = nome;
            DaTaCriacao = dataCriacao;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DaTaCriacao { get; set; }
    }
}