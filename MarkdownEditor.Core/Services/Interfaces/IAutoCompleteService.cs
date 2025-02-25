namespace MarkdownEditor.Core.Services.Interfaces;

public interface IAutoCompleteService
{
    void Clear();
    void NextChar(char n);
    IEnumerable<string> SuggestedEndings { get; }
}