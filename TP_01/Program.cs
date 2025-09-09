using Microsoft.AspNetCore.Hosting;
using TP_01;
using TP_01.Repositories;

//Feito por Eduardo Miranda CB3026604 & Cauã Barros CB3025179

var fakeRepository = new FakeBookRepository();

IWebHost host = new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .Build();

host.Run(); 