using AeroHubAPI.Data;
using Microsoft.EntityFrameworkCore;
using AeroHubAPI.Services.Interfaces; // Adicionado
using AeroHubAPI.Services; // Adicionado

var builder = WebApplication.CreateBuilder(args);

// Adicionar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar Controllers
builder.Services.AddControllers();

// Configurar CORS para o Next.js
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // URL do seu Next.js
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioService, UsuarioService>(); // << NOVO >>
// ... no Program.cs, seção de builder.Services ...
builder.Services.AddScoped<ICadastroService, CadastroService>();
builder.Services.AddScoped<IArquivoService, ArquivoService>(); // << NOVO >>
// ...

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowNextJS");

// Certifique-se de que esta linha está ANTES de app.UseAuthorization()
app.UseStaticFiles(); // << GARANTIR ISTO >> 

app.UseHttpsRedirection();
// ...

app.UseAuthorization();

app.MapControllers();

app.Run();