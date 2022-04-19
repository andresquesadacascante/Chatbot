var builder = WebApplication.CreateBuilder(args);

// Crea el servicio para el contexto de datos que se crea
builder.Services.AddDbContext<DataContext>(o =>
{
    // Le decimos que base de datos usar (SQL SERVER) e indicamos donde puede encontrar la cadena de conexion
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Permite usar vistas con controladores y controladores para API
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PreguntaRespuestas}/{action=Index}/{id?}");

app.Run();
