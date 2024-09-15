using FirstOne.Data;
using FirstOne.Repository;
using FirstOne.Reposotory.Inteface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalAPI.Models;
using Sprint3.Repository;
using Sprint3.Repository.Inteface;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<dbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sprint 3 NovaTech Solutions",
        Version = "v1",
        Description = "Documentação da API Sprint 3. ID's Gerados automaticamente(Post não precisa inserir Id)",
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddDbContext<dbContext>(o => o.UseInMemoryDatabase("Carrinhos"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/GetCarrinhos", async (dbContext context) =>
    await context.Carrinhos.ToListAsync());

app.MapPost("/AddCarrinho", async (Carrinho todo, dbContext context) =>
{
    context.Carrinhos.Add(todo);
    await context.SaveChangesAsync();
    return Results.Created($"/GetCarrinhos", todo);
});
app.MapGet("/gettodo/StatusON", async (dbContext context) =>
    await context.Carrinhos.Where(t => t.Status).ToListAsync());

app.MapGet("/GetCarrinho/StatusOFF", async (dbContext context) =>
    await context.Carrinhos.Where(t => !t.Status).ToListAsync());

app.MapGet("/GetCarrinho/{id}", async (int id, dbContext context) =>
    await context.Carrinhos.FindAsync(id) is Carrinho todo ? Results.Ok(todo) : Results.NotFound());

app.MapPut("/UpdateCarrinho/{id}", async (int id, Carrinho inputTodo, dbContext context) =>
{
    var findcarrinho = await context.Carrinhos.FindAsync(id);
    if (findcarrinho == null) return Results.NotFound();
    findcarrinho.Produtos = inputTodo.Produtos;
    findcarrinho.Status = inputTodo.Status;
    await context.SaveChangesAsync();
    return Results.Ok(findcarrinho);
});
app.MapDelete("/deletetodo/{id}", async (int id, dbContext context) =>
{
    var findcarrinho = await context.Carrinhos.FindAsync(id);
    if (findcarrinho == null) return Results.NotFound();

    context.Carrinhos.Remove(findcarrinho);
    await context.SaveChangesAsync();
    return Results.Ok("Deletado");
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
