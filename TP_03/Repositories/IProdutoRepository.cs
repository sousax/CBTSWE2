using CBTSWE2_TP03.Models;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace CBTSWE2_TP03.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProdutoById(int id);
        Task AddProduto(Produto produto);
        Task UpdateProduto(Produto produto);
        Task DeleteProduto(int id);
    }
}
