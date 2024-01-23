using MediatR;
using PipelineBehaviors.Commands;
using PipelineBehaviors.Entities;
using PipelineBehaviors.Enum;
using PipelineBehaviors.Repositories;
using PipelineBehaviors.Services;

namespace PipelineBehaviors.Handlers;

internal sealed class EnviarPedidoHandler(IPedidoRepository pedidoRepository, ICepServices cepServices) :
                                         IRequestHandler<EnviarPedidoCommand, CommandResult<Pedido>>
{
    public async Task<CommandResult<Pedido>> Handle(EnviarPedidoCommand request, CancellationToken cancellationToken)
    {
        await pedidoRepository.GerarPedidoEnviadoAsync(request.PedidoId, StatusPedido.EmSeparacao);

        var cepFoiValidado = await cepServices.ValidarEnderecoDeCepAsync(request.Cep);

        if (cepFoiValidado)
        {
            var commandResult = new CommandResult<Pedido>("OK", true);
            commandResult.AddData(new Pedido { Id = request.PedidoId });
        }

        return new CommandResult<Pedido>("O cep é de uma região que não existe entrega");
    }
}
