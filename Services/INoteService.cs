using NotesMcp.Dto;

namespace NotesMcp.Services;

public interface INoteService
{
    Task<List<Note>> GetAllNotes();

    Task<List<Note>> GetAllNotesByTag(string tagName);

    Task<List<Note>> GetAllNotesByTitle(string title);

    Task<Note?> GetNoteById(int Id);

    Task<Note> CreateNote(CreateNote createNote);

    Task<Note?> UpdateNote(UpdateNote updateNote);

    Task DeleteNote(int Id);
}