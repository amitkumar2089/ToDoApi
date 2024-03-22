using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/todo", async (AppDbContext dbContext) =>
{
    var items = await dbContext.ToDoItems.ToListAsync();

    return Results.Ok(items);
});

app.MapPost("api/todo", async (AppDbContext dbContext, ToDoItem toDoItem) =>
{
    await dbContext.ToDoItems.AddAsync(toDoItem);
    await dbContext.SaveChangesAsync();

    return Results.Created($"api/todo/{toDoItem.Id}", toDoItem);
});

app.UseHttpsRedirection();

app.Run();
