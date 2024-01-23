using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PipelineBehaviors.Entities;

namespace PipelineBehaviors.Commands;

public interface IComandoBase
{

    void ValidarComando();
}

public class EnviarPedidoCommand : Notifiable<Notification>, IRequest<CommandResult<Pedido>>
{
    public Guid PedidoId { get; set; }
    public string? Cep { get; set; }
    public string? Estado { get; set; }

    public EnviarPedidoCommand(Guid pedidoId, string? cep, string? estado)
    {
        PedidoId = pedidoId;
        Cep = cep;
        Estado = estado;

        ValidarComando();
    }

    public void ValidarComando()
    {
        AddNotifications(new Contract<Notification>()
            .IsNullOrEmpty(nameof(PedidoId), "Deve ser válido")
            .IsNullOrEmpty(nameof(Cep), "Deve ser válido")
            .IsNullOrEmpty(nameof(Estado), "Deve ser válido"));
    }
}
