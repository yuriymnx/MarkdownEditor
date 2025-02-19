using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MarkdownEditor.Utils;
using MarkdownEditor.ViewModels.Base;

namespace MarkdownEditor.ViewModels.Controls;

internal partial class MarkdownEditorViewModel : ViewModelBase
{
    private readonly IMessenger _messenger;

    [ObservableProperty]
    private string _markdownText;

    public MarkdownEditorViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        _markdownText = string.Empty;
    }

    partial void OnMarkdownTextChanged(string value) => _messenger.Send(new MarkdownUpdatedMessage(value));
}