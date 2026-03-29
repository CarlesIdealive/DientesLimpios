using DientesLimpios.API.Middlewares;
using DientesLimpios.Aplicacion;
using DientesLimpios.Identidad;
using DientesLimpios.Identidad.Modelos;
using DientesLimpios.Infraestructura;
using DientesLimpios.Persistencia;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opciones =>
{
    //Protege todas las rutas de la API, para que solo los usuarios autenticados puedan acceder a ellas
    //Protegemos los endpoints de la API con una política de autorización que requiere que el usuario tenga el claim "esadmin".
    //Esto significa que solo los usuarios que tengan este claim podrán acceder a los endpoints protegidos por esta política.
    opciones.Filters.Add(new AuthorizeFilter("esadmin"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Agregamos los servicios de la aplicación y la persistencia
builder.Services.AgregarServiciosDeAplicacion();
builder.Services.AgregarServiciosDePersistencia();
builder.Services.AgregarServiciosDeInfraestructura();
builder.Services.AgregarServiciosDeIdentidad();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
//PAra manejar los EnpPoints de Identidad - !!!!!
app.MapIdentityApi<Usuario>();
// Agregamos el middleware de manejo de excepciones personalizado
app.UseManejadorExcepciones();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
