using Microsoft.EntityFrameworkCore;

namespace NotesMcp.Data;

public class NoteContext : DbContext
{
    public DbSet<Note> Notes { get; set; }

    public string DbPath { get; }

    public NoteContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "notes.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}