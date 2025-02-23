using CommunityToolkit.Mvvm.Input;
using MarkdownEditor.ViewModels.Base;
using MarkdownEditor.ViewModels.Controls;

namespace MarkdownEditor.ViewModels;
public partial class MainViewModel : ViewModelBase
{
    public MarkdownEditorViewModel EditorViewModel { get; }

    public MainViewModel(MarkdownEditorViewModel editorViewModel)
    {
        EditorViewModel = editorViewModel;
    }

    [RelayCommand]
    private void TogglePreview()
    {
        EditorViewModel.TogglePreviewCommand.Execute(null);
    }
}
