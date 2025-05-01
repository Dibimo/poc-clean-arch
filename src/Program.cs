using cliente_solution.infrastructure;
using cliente_solution.useCases.ClienteContatoUseCases;
using cliente_solution.useCases.ClienteUseCases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adicionando o dbcontext.
//para fins de simplificação, vou utilizar o SQLite, mas o processo é o mesmo para qualquer outro tipo de banco de dados
builder.Services.AddDbContext<ClienteSolutionContext>(op => {
    op.UseSqlite("Data Source=clientes.db");
});

//(sim, não precisamos definir uma interface para tudo rsrsrsrs)
builder.Services.AddScoped<CriarClienteContatoUseCase>();
builder.Services.AddScoped<BuscarTodosClienteContatosUseCase>();
builder.Services.AddScoped<AtualizarClienteContatoUseCase>();
builder.Services.AddScoped<RemoverClienteContatoUseCase>();

builder.Services.AddScoped<CriarClienteUseCase>();
builder.Services.AddScoped<BuscarTodosClientesUseCase>();
builder.Services.AddScoped<AtualizarClienteUseCase>();
builder.Services.AddScoped<RemoverClienteUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
