using Energia1.domain;
namespace Energia1.repos
{
    public interface IEnergiaRepos: IBaseRepos<Energia>
    {
        string MaiorConsumo();
        string MenorConsumo();
    }
}