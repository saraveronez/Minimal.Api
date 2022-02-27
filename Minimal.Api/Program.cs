using Minimal.Api.Data;
using Minimal.Api.Models;
using Minimal.Api.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/user", (AppDbContext context) =>
{
    var users = context.Users.ToList();
    return Results.Ok(users);

}).Produces<List<User>>();

app.MapPost("/user", (AppDbContext context, CreateUserViewModel viewModel) =>
{
    if (!viewModel.IsValid)
        return Results.BadRequest(viewModel.Notifications);

    var user = viewModel.MapTo();
    context.Users.Add(user);
    context.SaveChanges();

    return Results.Created($"{user.Id}", user);
});

app.Run();
