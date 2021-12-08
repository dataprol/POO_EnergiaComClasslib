using Energia1.domain;

namespace Energia1.repos
{
    public interface IClienteRepository: IBaseRepos<Cliente>
    {
        string MaiorConsumoCliente(int id);
        string MenorConsumoCliente(int id);
    }
}