using System.ComponentModel;

namespace NotesMcp.Dto;

public class UpdateNote
{
    [Description("The id of the note that is being updated")]
    public required int Id { get; set; }

    [Description("Optional updated note title. If note provided then the original note title will be kept")]
    public string? Title { get; set; }

    [Description("Optional updated note content. If not provided then the original note content will be kept.")]
    public string? Content { get; set; }

    [Description("Optional updated note tag list. If note provided then the original note tag list will be kept")]
    public List<string>? Tags { get; set; }
}