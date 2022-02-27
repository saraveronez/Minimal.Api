using Flunt.Notifications;
using Flunt.Validations;
using Minimal.Api.Models;

namespace Minimal.Api.ViewModels
{
    public class CreateUserViewModel : Notifiable<Notification>
    {
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }

        public User MapTo()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Informe o nome")
                .IsGreaterThan(Nome, 2, "Nome deve conter mais de dois caracteres."));

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(DataCriacao, "Informe a data criação")
                .IsLowerOrEqualsThan(DataCriacao, DateTime.Now, "Data criação não pode ser maior que data atual."));

            return new User(Guid.NewGuid(), Nome, DataCriacao);
        }
    }
}
