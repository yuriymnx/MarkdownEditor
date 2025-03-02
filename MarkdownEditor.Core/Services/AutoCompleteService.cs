using MarkdownEditor.Core.Services.Interfaces;
using System.Text;

namespace MarkdownEditor.Core.Services;

public class AutoCompleteService : IAutoCompleteService
{
    private readonly HashSet<string> _completions = new()
    {
        "*", "_", "~~", "''", "**", "__", "#", "##", "###", "- ", "* ", "+ ", "1. ", "> ", "`", "```",
        "[text](url)", "![alt](url)"
    };

    private readonly StringBuilder _currentSequence = new();
    private char? _lastChar;
    private bool _isInsideCodeBlock = false;

    public void Clear()
    {
        _currentSequence.Clear();
        _lastChar = null;
        _isInsideCodeBlock = false;
    }

    public void NextChar(char c)
    {
        _lastChar = c;
        _currentSequence.Append(c);

        if (c == '`' && _currentSequence.ToString().EndsWith("```"))
        {
            _isInsideCodeBlock = !_isInsideCodeBlock;
            _currentSequence.Clear();
        }
        else if (!_isInsideCodeBlock && !IsCurrentSequenceValid())
        {
            _currentSequence.Clear();
        }
    }


    public IEnumerable<string> SuggestedEndings
    {
        get
        {
            if (!_lastChar.HasValue || _currentSequence.Length == 0)
                return Enumerable.Empty<string>();

            var currentString = _currentSequence.ToString();
            return _completions.Where(x => x.StartsWith(currentString) && x.Length > currentString.Length);
        }
    }

    public bool ShouldAutoClose(string input)
    {
        return _completions.Contains(input) && input.Length > 1 && input[0] == input[^1];
    }

    public bool IsInsideCodeBlock()
    {
        return _isInsideCodeBlock;
    }

    #region  private
    /// <summary>
    /// Проверяет текущую последовательность на соответствие автодополнения.
    /// </summary>
    private bool IsCurrentSequenceValid()
    {
        if (_currentSequence.Length == 0)
            return false;

        var currentString = _currentSequence.ToString();
        return _completions.Any(x => x.StartsWith(currentString));
    }
    #endregion

}
