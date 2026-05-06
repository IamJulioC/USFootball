using Microsoft.EntityFrameworkCore;
using USFootball;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source= teams.db"));

var app = builder.Build();

app.MapGet("/teams", async (AppDbContext db) =>
{
    return await db.Teams.ToListAsync();
});

app.MapGet("/teams/{id}", async (int id, AppDbContext db) =>
{
    var team = await db.Teams.FindAsync(id);
    return team is not null ? Results.Ok(team) : Results.NotFound("Time não encontrado");
});

app.MapPost("/teams", async (AppDbContext db, Team newTeam) =>
{
    db.Teams.Add(newTeam);
    await db.SaveChangesAsync();

    return Results.Created($"O time {newTeam.Nome} foi adicionado com sucesso", newTeam);
});

app.MapPut("/teams/{id}", async (int id, AppDbContext db, Team updatedTeam) =>
{
    var team = await db.Teams.FindAsync(id);
    if (team is null ) return Results.NotFound("Time não encontrado");

    team.Nome = updatedTeam.Nome;
    team.Cidade = updatedTeam.Cidade;
    team.SuperBowlsGanhos = updatedTeam.SuperBowlsGanhos;
    team.JogosForaDoPais = updatedTeam.JogosForaDoPais;

    await db.SaveChangesAsync();
    return Results.Ok(team);
});

app.MapPatch("/teams/{id}", async (int id, AppDbContext db, Team updatedFields) =>
{
    var team = await db.Teams.FindAsync(id);
    if (team is null) return Results.NotFound("Time não encontrado");

    if (!string.IsNullOrEmpty(updatedFields.Nome)) team.Nome = updatedFields.Nome;
    if (!string.IsNullOrEmpty(updatedFields.Cidade)) team.Cidade = updatedFields.Cidade;
    if (updatedFields.SuperBowlsGanhos != 0) team.SuperBowlsGanhos = updatedFields.SuperBowlsGanhos;
    if (updatedFields.JogosForaDoPais != 0) team.JogosForaDoPais = updatedFields.JogosForaDoPais;

    await db.SaveChangesAsync();
    return Results.Ok($"Time {team.Nome} atualizado com sucesso");
});

app.Run();
