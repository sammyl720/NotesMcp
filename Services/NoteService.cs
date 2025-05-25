using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NotesMcp.Data;
using NotesMcp.Dto;

namespace NotesMcp.Services;

public class NoteService(NoteContext context) : INoteService
{
    public async Task<Note> CreateNote(CreateNote createNote)
    {
        var Note = new Note()
        {
            Title = createNote.Title,
            Content = createNote.Content,
            Tags = createNote.Tags
        };

        context.Notes.Add(Note);
        await context.SaveChangesAsync();
        return Note;
    }

    public async Task DeleteNote(int Id)
    {
        var note = await context.Notes.FindAsync(Id);

        if (note == null) return;

        context.Notes.Remove(note);

        await context.SaveChangesAsync();
    }

    public async Task<List<Note>> GetAllNotes()
    {
        var notes = await context.Notes.ToListAsync();
        return notes;
    }

    public async Task<List<Note>> GetAllNotesByTag(string tagName)
    {
        var notes = await context.Notes
                            .Where(note =>
                                    note.Tags.Any(t => t.ToLower().Equals(tagName.ToLower()))).ToListAsync();
        return notes;
    }

    public async Task<List<Note>> GetAllNotesByTitle(string title)
    {
        var notes = await context.Notes
            .Where(note => note.Title.ToLower().Contains(title.ToLower()))
            .ToListAsync();
        return notes;
    }


    public async Task<Note?> GetNoteById(int Id)
    {
        var note = await context.Notes.FindAsync(Id);
        return note;
    }

    public async Task<Note?> UpdateNote(UpdateNote updateNote)
    {
        var note = await GetNoteById(updateNote.Id);
        if (note == null) return null;

        note.Title = updateNote.Title ?? note.Title;
        note.Content = updateNote.Content ?? note.Content;
        note.Tags = updateNote.Tags ?? note.Tags;
        note.LastUpdated = DateTime.Now;
        await context.SaveChangesAsync();
        return note;
    }
}

[JsonSerializable(typeof(List<Note>))]
internal sealed partial class NoteSerializerContext : JsonSerializerContext
{

}