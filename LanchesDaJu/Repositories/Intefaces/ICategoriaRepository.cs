using LanchesDaJu.Models;

namespace LanchesDaJu.Repositories.Intefaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
