using MarkdownEditor.Core.Services.Interfaces;

namespace MarkdownEditor.Core.Services;

public class AutoCompleteService : IAutoCompleteService
{
    private readonly HashSet<string> _completions = new()
    {
        "*",
        "_",
        "~~",
        "''",
        "**",
        "__"
    };

    private readonly List<char> _currentSequence = new();
    private char? _lastChar;

    public void Clear()
    {
        _currentSequence.Clear();
        _lastChar = null;
    }

    public void NextChar(char c)
    {
        _lastChar = c;
        _currentSequence.Add(c);

        if (!IsCurrentSequenceValid())
        {
            _currentSequence.Clear();
        }
    }

    public IEnumerable<string> SuggestedEndings
    {
        get
        {
            if (!_lastChar.HasValue || _currentSequence.Count == 0)
                return Enumerable.Empty<string>();

            string currentString = new(_currentSequence.ToArray());
            return _completions.Where(x => x.StartsWith(currentString) && x.Length > currentString.Length);
        }
    }

    private bool IsCurrentSequenceValid()
    {
        if (_currentSequence.Count == 0)
            return false;

        string currentString = new(_currentSequence.ToArray());
        return _completions.Any(x => x.StartsWith(currentString));
    }
}