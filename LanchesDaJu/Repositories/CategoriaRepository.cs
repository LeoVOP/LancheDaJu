using LanchesDaJu.Context;
using LanchesDaJu.Models;
using LanchesDaJu.Repositories.Intefaces;

namespace LanchesDaJu.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
