using Microsoft.OpenApi.Models;
using PizzaStore.Db;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c =>
      {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizza Santi API", Description = "Keep a documentation for our API's", Version = "v1" });
      });
}

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Santi API V1");
    });
}

app.MapGet("/", () => "Hello World for UCU Students!");
app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));

app.MapPost("/delay/{ms}", (int ms) => PizzaDB.Delay = ms);
app.MapGet("/delay/", () => PizzaDB.Delay);

app.MapPost("/error/{onOff}", (bool onOff) => PizzaDB.Error = onOff);
app.MapGet("/error/", () => PizzaDB.Error);

app.Run();
