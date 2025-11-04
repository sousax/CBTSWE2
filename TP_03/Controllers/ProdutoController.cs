using CBTSWE2_TP03.Models;
using CBTSWE2_TP03.Repositories;
using Microsoft.AspNetCore.Mvc;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace CBTSWE2_TP03.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository; 

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            { 
                _produtoRepository.AddProduto(produto);
                return RedirectToAction("Index", "Home");   
            }
            else
            {
                return View(produto);
            }
        }

        [HttpGet]
        [Route("Produto/Editar/{produtoId:int}")]
        public async Task<IActionResult> Editar(int produtoId)
        {
            var produto = await _produtoRepository.GetProdutoById(produtoId);
            if (produto == null)
                return NotFound();

            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                await _produtoRepository.UpdateProduto(produto);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(produto);
            }
        }

        [HttpPost]
        [Route("Produto/Excluir/{produtoId:int}")]
        public async Task<IActionResult> Excluir(int produtoid)
        {
            var produto = await _produtoRepository.GetProdutoById(produtoid);
            if (produto == null)
                return NotFound();

            if(!ModelState.IsValid)
                return RedirectToAction("Index", "Home");
            
            await _produtoRepository.DeleteProduto(produtoid);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("Produto/Detalhes/{produtoId:int}")]
        public async Task<IActionResult> Detalhes(int produtoId)
        {
            var produto = await _produtoRepository.GetProdutoById(produtoId);
            if (produto == null)
                return NotFound();
            return View(produto);
        }
    }
}
