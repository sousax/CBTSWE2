using System.Diagnostics;
using CBTSWE2_TP03.Models;
using CBTSWE2_TP03.Repositories;
using Microsoft.AspNetCore.Mvc;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

namespace CBTSWE2_TP03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdutoRepository _produtoRepository;

        public HomeController(ILogger<HomeController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.GetProdutos();
            return View(produtos);
        }

        public IActionResult Creditos()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
