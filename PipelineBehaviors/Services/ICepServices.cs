namespace PipelineBehaviors.Services;

public interface ICepServices
{
    Task<bool> ValidarEnderecoDeCepAsync(string? cep);
}

public class CepServices : ICepServices
{
    public Task<bool> ValidarEnderecoDeCepAsync(string? cep)
    {
        return Task.FromResult(true);
    }
}
