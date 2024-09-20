using BlazeCore.Server.Infrastructure;
using BlazeCore.Server.Infrastructure.Mediatr;
using BlazeCore.Server.Persistance;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));

builder.Services.Scan(
    x =>
    {
        x.FromAssemblies(typeof(Program).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(AbstractValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime();
    });

builder.Services.AddTransient<ITodoItemRepository, InMemoryTodoItemRepository>();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();