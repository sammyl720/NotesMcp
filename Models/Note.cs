namespace NotesMcp;

public class Note
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public required List<string> Tags { get; set; }

    public DateTime LastUpdated { get; set; } = DateTime.Now;
}