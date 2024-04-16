using InjecaoDependencia.Implementations;
using InjecaoDependencia.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyedSingleton<ITesteInjecao, TesteInjecao>("InjecaoSingletonUm");
builder.Services.AddKeyedSingleton<ITesteInjecao, TesteInjecao>("InjecaoSingletonDois");
builder.Services.AddKeyedScoped<ITesteInjecao, TesteInjecao>("InjecaoScopedUm");
builder.Services.AddKeyedScoped<ITesteInjecao, TesteInjecao>("InjecaoScopedDois");
builder.Services.AddKeyedTransient<ITesteInjecao, TesteInjecao>("InjecaoTransientUm");
builder.Services.AddKeyedTransient<ITesteInjecao, TesteInjecao>("InjecaoTransientDois");


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
