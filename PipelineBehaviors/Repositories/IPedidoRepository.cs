using PipelineBehaviors.Enum;

namespace PipelineBehaviors.Repositories;

public interface IPedidoRepository
{
    Task GerarPedidoEnviadoAsync(Guid idPedido, StatusPedido statusPedido);
}

public class PedidoRepository : IPedidoRepository
{
    public Task GerarPedidoEnviadoAsync(Guid idPedido, StatusPedido statusPedido)
    {
        return Task.CompletedTask;
    }
}
