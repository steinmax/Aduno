var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ReSign.Database.Logic.Controllers.InteractionController>();
builder.Services.AddTransient<ReSign.Database.Logic.Controllers.OrganisationController>();
builder.Services.AddTransient<ReSign.Database.Logic.Controllers.QRTokenController>();
builder.Services.AddTransient<ReSign.Database.Logic.Controllers.RoomController>();
builder.Services.AddTransient<ReSign.Database.Logic.Controllers.UserController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
