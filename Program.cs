using Proyec_Tienda_musica.Modelos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registra el servicio de Razor Pages en el contenedor de dependencias.
// Permite que las páginas .cshtml funcionen con sus PageModels correspondientes.
// Añade servicios al contenedor.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias con SQL Server
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaDB")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirige automáticamente las peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Permite servir archivos estáticos desde la carpeta wwwroot (CSS, JS, imágenes)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapea las rutas de las páginas Razor
app.MapRazorPages();

// Mapea las rutas de los controladores de la API REST
app.MapControllers();

app.Run();
