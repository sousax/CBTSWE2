using CBTSWE2_TP03.Data;
using CBTSWE2_TP03.Models;
using Microsoft.EntityFrameworkCore;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace CBTSWE2_TP03.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddProduto(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public Task DeleteProduto(int id)
        {   
            Produto? produtoEncontrado = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if(produtoEncontrado == null)
                throw new KeyNotFoundException($"Produto com Id {id} não encontrado.");

            _context.Produtos.Remove(produtoEncontrado);
            return _context.SaveChangesAsync();
        }

        public async Task<Produto?> GetProdutoById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
