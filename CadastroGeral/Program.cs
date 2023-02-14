using CadastroGeral.Connection;
using CadastroGeral.Helper;
using CadastroGeral.Interfaces;
using CadastroGeral.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // Add services to the container.

//String de conex�o com o banco de dados, 1 :
//https://www.youtube.com/watch?v=zr3QiQDZ0-k
builder.Services.AddDbContext<BancoContext>
    (options => options.UseSqlServer
    (connectionString: @"Data Source=SRVDBDESENV;Initial Catalog=TestesFrancisco2;Integrated Security=True;"));


//Injetar depend�ncias para sess�o de usu�rio
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Inje��o de depend�ncia para classe de implementa��o
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessaoUsuario, SessaoUsuario>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<IEmail, Email>();


//Valida��o dos Cokies da sess�o do usu�rio
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Permitir sess�o usu�rio
app.UseSession();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    //Alterar para cair na tela de login
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();
