using LanchesDaJu.Models;

namespace LanchesDaJu.Repositories.Intefaces
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int Lancheid);
    }
}
