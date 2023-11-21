 using Academia_WebApp.DBContext;
using Academia_WebApp.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar o contexto do banco de dados
builder.Services.AddDbContext<acadDbContext>(options =>
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    options.UseSqlServer(configuration.GetConnectionString("myconn"));
});

// Registrar a implementação
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IExercicioRepositorio, ExercicioRepositorio>();

//builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
