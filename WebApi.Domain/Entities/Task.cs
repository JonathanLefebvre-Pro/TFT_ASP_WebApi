namespace WebApi.Domain.Entities;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public bool IsCompleted { get; set; }
}
