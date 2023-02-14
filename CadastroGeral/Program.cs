using CadastroGeral.Connection;
using CadastroGeral.Helper;
using CadastroGeral.Interfaces;
using CadastroGeral.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); // Add services to the container.

//String de conexão com o banco de dados, 1 :
//https://www.youtube.com/watch?v=zr3QiQDZ0-k
builder.Services.AddDbContext<BancoContext>
    (options => options.UseSqlServer
    (connectionString: @"Data Source=SRVDBDESENV;Initial Catalog=TestesFrancisco2;Integrated Security=True;"));


//Injetar dependências para sessão de usuário
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Injeção de dependência para classe de implementação
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<ISessaoUsuario, SessaoUsuario>();
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();
builder.Services.AddScoped<IEmail, Email>();


//Validação dos Cokies da sessão do usuário
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

//Permitir sessão usuário
app.UseSession();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    //Alterar para cair na tela de login
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();
