var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<Aduno.Database.Logic.Controllers.InteractionController>();
builder.Services.AddTransient<Aduno.Database.Logic.Controllers.RoomController>();
builder.Services.AddTransient<Aduno.Database.Logic.Controllers.UserController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//Enable swagger also for production
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//Enable once we know how to run it in parallel to nginx (port 80)
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
