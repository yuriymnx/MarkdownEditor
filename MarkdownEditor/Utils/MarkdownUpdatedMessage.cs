using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MarkdownEditor.Utils;

public class MarkdownUpdatedMessage : ValueChangedMessage<string>
{
    public MarkdownUpdatedMessage(string value) : base(value) { }
}