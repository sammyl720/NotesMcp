using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;
using NotesMcp.Dto;
using NotesMcp.Services;

namespace NotesMcp.Tools;

[McpServerToolType]
public sealed class NotesTool
{
    [McpServerTool, Description("Get all saved notes.")]
    public static async Task<string> GetAllNotes(
        INoteService noteService
    )
    {
        var notes = await noteService.GetAllNotes();
        return JsonSerializer.Serialize(notes);
    }

    [McpServerTool, Description("Get all saved notes that have the provide tag.")]
    public static async Task<string> GetAllNotesByTagName(
        INoteService noteService,
        [Description("Name of tag")] string tagName
    )
    {
        var notes = await noteService.GetAllNotesByTag(tagName);
        return JsonSerializer.Serialize(notes);
    }

    [McpServerTool, Description("Get all saved notes that have a title that contain the provided title text.")]
    public static async Task<string> GetAllNotesByTitle(
        INoteService noteService,
        [Description("Text of title")] string title
    )
    {
        var notes = await noteService.GetAllNotesByTitle(title);
        return JsonSerializer.Serialize(notes);
    }


    [McpServerTool, Description("Create a new note")]
    public static async Task<string> SaveNewNote(
        INoteService noteService,
        [Description("The new note to create")] CreateNote newNote
    )
    {
        var savedNote = await noteService.CreateNote(newNote);
        return JsonSerializer.Serialize(savedNote);
    }

    [McpServerTool, Description("Update a note")]
    public static async Task<string> UpdateNote(
        INoteService noteService,
        [Description("The note with the updated content")] UpdateNote updateNote
    )
    {
        var note = await noteService.UpdateNote(updateNote);
        return JsonSerializer.Serialize(note);
    }

    [McpServerTool, Description("Delete a note")]
    public static async Task<string> DeleteNote(
        INoteService noteService,
        [Description("The id of the note to delete")] int id
    )
    {
        await noteService.DeleteNote(id);
        return JsonSerializer.Serialize(new { Message = "Note Deleted" });
    }
}