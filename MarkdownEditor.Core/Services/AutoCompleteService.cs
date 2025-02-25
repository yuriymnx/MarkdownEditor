using MarkdownEditor.Core.Services.Interfaces;

namespace MarkdownEditor.Core.Services;

public class AutoCompleteService : IAutoCompleteService
{
    private readonly HashSet<string> _completions = new()
    {
        "*",
        "_",
        "~~",
        "'",
    };

    private readonly List<char> _currentSequence = new(5);

    private char? _lastChar;

    public void Clear()
    {
        _currentSequence.Clear();
    }

    public void NextChar(char c)
    {
        _lastChar = c;
        if (IsCharControlling())
        {
            _currentSequence.Add(c);
        }

        else
        {
            _currentSequence.Clear();
        }
    }


    public IEnumerable<string> SuggestedEndings => _completions.Where(x => x.ElementAtOrDefault(_currentSequence.Count) == _lastChar);

    private bool IsCharControlling()
    {
        return _completions.Any(x => x.ElementAtOrDefault(_currentSequence.Count) == _lastChar);
    }
}