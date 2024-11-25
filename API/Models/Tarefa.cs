namespace API.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
