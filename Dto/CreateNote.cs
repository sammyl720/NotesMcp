using System.ComponentModel;

namespace NotesMcp.Dto;

public class CreateNote
{
    [Description("Title of note")]
    public required string Title { get; set; }

    [Description("Actual content of the note")]
    public required string Content { get; set; }

    [Description("A list of tag labels for this note.")]
    public required List<string> Tags { get; set; }
}