namespace MarkdownEditor.Core.Services.Interfaces;

/// <summary>
/// Обеспечивает функцию автодополнения для редактирования Markdown, включая поддержку различных элементов Markdown.
/// Отслеживает ввод пользователя и предлагает возможные завершения на основе предопределённых последовательностей.
/// </summary>
public interface IAutoCompleteService
{
    /// <summary>
    /// Очищает текущую последовательность ввода и сбрасывает внутреннее состояние.
    /// </summary>
    void Clear();

    /// <summary>
    /// Обрабатывает следующий символ в последовательности ввода.
    /// Отслеживает синтаксис Markdown и определяет, применимо ли автодополнение.
    /// </summary>
    /// <param name="c">Следующий символ, введённый пользователем.</param>
    void NextChar(char с);

    /// <summary>
    /// Возвращает список предложенных завершений на основе текущей последовательности ввода.
    /// </summary>
    IEnumerable<string> SuggestedEndings { get; }

    /// <summary>
    /// Определяет, должна ли указанная последовательность ввода автоматически закрываться (например, **, __, `, ~~).
    /// </summary>
    /// <param name="input">Последовательность ввода для проверки.</param>
    /// <returns>True, если последовательность должна быть автоматически закрыта, иначе false.</returns>
    public bool ShouldAutoClose(string input);

    /// <summary>
    /// Проверяет, находится ли пользователь внутри блока кода Markdown.
    /// </summary>
    /// <returns>True, если внутри блока кода, иначе false.</returns>
    public bool IsInsideCodeBlock();
}