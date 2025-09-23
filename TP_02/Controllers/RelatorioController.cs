using CBTSWE2_TP02.Data;
using CBTSWE2_TP02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CBTSWE2_TP02.Controllers
{
    //Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;
        public RelatorioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            BL[] listaBLs = GetListaDeBLs().ToArray();
            Container[] containers = GetListaDeContainers().ToArray();

            ViewBag.ListaDeBLs = listaBLs;
            ViewBag.ListaDeContainers = containers;

            return View();
        }

        private List<BL> GetListaDeBLs()
        {
            BL[] listaBLs = _context.BLs.ToArray();
            return listaBLs.ToList();
        }

        private List<Container> GetListaDeContainers()
        {
            Container[] listaDeContainers = _context.Containers.ToArray();
            return listaDeContainers.ToList();
        }
    }
}
