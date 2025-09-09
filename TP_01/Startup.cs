using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using TP_01.Controllers;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179
namespace TP_01
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            var controller = new BookController();

            builder.MapGet("livro/nome", controller.GetBookName);
            builder.MapGet("livro", controller.GetBookToString);
            builder.MapGet("livro/autores", controller.GetBookAuthorNames);
            builder.MapGet("livro/apresentar", controller.ApresentarLivro);

            builder.DefaultHandler = new RouteHandler(context =>
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("Rota não encontrada.");
            });

            var routes = builder.Build();
            app.UseRouter(routes);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }
    }
}
