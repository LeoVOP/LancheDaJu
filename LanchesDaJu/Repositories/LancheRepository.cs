using LanchesDaJu.Context;
using LanchesDaJu.Models;
using LanchesDaJu.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesDaJu.Repositories
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);
        //Consulta LINQ com o método Include que permite obter os dados relacionados incuindo-os no resultado da consulta.

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches.
            Where(p => p.IsLanchePreferido)
            .Include(c => c.Categoria);
        //Consulta LINQ com método WHERE e Include para filtrar somente os lanches cuja a propriedade IsLanchePreferido for igual a true e incluir as categorias no resultado da consulta
        public Lanche GetLancheById(int lancheId)
        {
            return _context.Lanches.
            FirstOrDefault(l => l.LancheId == lancheId);
            //Consulta LINQ com método FirstOrDefault que retornará o primeiro elemento de uma sequência ou um valor padrao caso não seja encontrado nenhum elemento.
        }
    }
}
