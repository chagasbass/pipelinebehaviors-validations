using MediatR;
using PipelineBehaviors.Commands;
using PipelineBehaviors.Entities;
namespace PipelineBehaviors.Behaviors;

public class EnviarPedidoValidationBehavior<TRequest, TResponse>(ILogger<EnviarPedidoValidationBehavior<TRequest, TResponse>> logger)
  : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var enviarPedidoCommand = request as EnviarPedidoCommand;

        if (!enviarPedidoCommand.IsValid)
        {
            logger.LogError("Envio de comando Inválido");

            var commandResult = new CommandResult<Pedido>("Erro");
            commandResult.AddNotifications(enviarPedidoCommand.Notifications.ToList());

            var response = (TResponse)Activator.CreateInstance(typeof(TResponse), commandResult);

            return await Task.FromResult(response);
        }

        return await next();
    }
}
