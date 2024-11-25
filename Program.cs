app.MapPut("/api/tarefas/alterar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] int id) =>
{
    var tarefa = ctx.Tarefas.Find(id);
    if (tarefa == null) return Results.NotFound("Tarefa não encontrada");

    tarefa.Concluida = !tarefa.Concluida;
    ctx.SaveChanges();
    return Results.Ok(tarefa);
});

app.MapGet("/api/tarefas/naoconcluidas", ([FromServices] AppDataContext ctx) =>
{
    var naoConcluidas = ctx.Tarefas
        .Include(x => x.Categoria)
        .Where(x => !x.Concluida)
        .ToList();
    return Results.Ok(naoConcluidas);
});

app.MapGet("/api/tarefas/concluidas", ([FromServices] AppDataContext ctx) =>
{
    var concluidas = ctx.Tarefas
        .Include(x => x.Categoria)
        .Where(x => x.Concluida)
        .ToList();
    return Results.Ok(concluidas);
});
