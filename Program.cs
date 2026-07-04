using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<LennyDbContext>(options
 => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<IPicRepository, PicRepository>();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseCors(p=> p.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();


app.MapGet("/pics", (IPicRepository picRepository) =>
    picRepository.GetAll()).Produces<List<PicDto>>(StatusCodes.Status200OK);

app.MapGet("/pic/{id:int}", async (int id, IPicRepository picRepository) =>
{
    var result = await picRepository.Get(id);
    if (result == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);
});


app.Run();
