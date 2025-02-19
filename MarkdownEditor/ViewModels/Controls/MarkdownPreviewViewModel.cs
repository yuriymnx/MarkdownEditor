using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MarkdownEditor.ViewModels.Base;
using Markdig;
using MarkdownEditor.Utils;

namespace MarkdownEditor.ViewModels.Controls;

internal partial class MarkdownPreviewViewModel : ViewModelBase
{
    // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
    private readonly IMessenger _messenger;

    [ObservableProperty]
    private string _htmlPreview = string.Empty;

    public MarkdownPreviewViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        _messenger.Register<MarkdownUpdatedMessage>(this, (recipient, message) =>
        {
            HtmlPreview = Markdown.ToHtml(message.Value);
        });
        HtmlPreview = string.Empty;
    }
}