using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Markdig;
using MarkdownEditor.ViewModels.Base;

namespace MarkdownEditor.ViewModels.Controls;

public partial class MarkdownEditorViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _markdownText;

    [ObservableProperty]
    private string? _htmlPreview;

    [ObservableProperty]
    private bool _isPreviewVisible;

    [RelayCommand]
    private void TogglePreview()
    {
        IsPreviewVisible = !IsPreviewVisible;
    }

    public MarkdownEditorViewModel()
    {
        IsPreviewVisible = true;
        MarkdownText = @"<b> abracadabra </b>";
    }

    partial void OnMarkdownTextChanged(string value)
    {
        HtmlPreview = Markdown.ToHtml(value);
    }
}