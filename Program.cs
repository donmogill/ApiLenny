using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<LennyDbContext>(options
 => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
});

builder.Services.AddScoped<IPicRepository, PicRepository>();
builder.Services.AddScoped<IShowRepository, ShowRepository>();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(Program).Assembly));


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

var app = builder.Build();

app.MapControllers();

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

app.UseStaticFiles();


app.MapGet("/pics", (IPicRepository picRepository) =>
    picRepository.GetAll()).Produces<List<PicDto>>(StatusCodes.Status200OK);

app.MapGet("/pic/{id:int}", async (int id, IPicRepository picRepository, ILogger<Program> logger) =>
{
    var result = await picRepository.Get(id);
    if (result == null)
    {
        logger.LogWarning("Pic was not found in the database.");
        return Results.NotFound();
    }
    return Results.Ok(result);
});

/*
app.MapPost("/pics", async ([FromBody] PicDto dto, IPicRepository picRepository) =>
{
    if (!MiniValidator.TryValidate(dto, out var errors))
    {
        return Results.ValidationProblem(errors);
    }

    var result = picRepository.Add(dto);
    return Results.Created($"/pic/{dto.Id}", result);
}).ProducesValidationProblem().Produces<PicDto>(StatusCodes.Status201Created);
*/

app.MapPost("/upload", async ([FromBody]IFormFile file) =>
{
    
    //var result = picRepository.UploadFile(file);
    //return Results.Created($"/pics", result);
}).DisableAntiforgery();


app.MapPut("/pics/{id:int}", async (int id, [FromBody] PicDto dto, IPicRepository picRepository) =>
{
    if (await picRepository.Get(id) == null)
    {
        return Results.NotFound();
    }
    var result = picRepository.Update(dto);
    if (result == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);
}).Produces<PicDto>(StatusCodes.Status200OK);

app.MapDelete("/pics/{id:int}", async (int id, IPicRepository picRepository) =>
{
    if (await picRepository.Get(id) == null)
    {
        return Results.Problem($"Pic with id {id} not found", 
            statusCode: StatusCodes.Status404NotFound);
    }
    var result = picRepository.Delete(id);
    if (result == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);    
}).ProducesProblem(404).Produces(StatusCodes.Status200OK); 

app.MapDelete("/shows/{id:int}", async (int id, IShowRepository showRepository) =>
{
    var showEntity = await showRepository.Get(id);
    if (showEntity == null)
    {
        return Results.Problem($"Show with id {id} not found", 
            statusCode: StatusCodes.Status404NotFound);
    }
    var result = showRepository.Delete(showEntity);
    await showRepository.SaveChangesAsync();
    if (result == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(result);    
}).ProducesProblem(404).Produces(StatusCodes.Status200OK); 

app.Run();
