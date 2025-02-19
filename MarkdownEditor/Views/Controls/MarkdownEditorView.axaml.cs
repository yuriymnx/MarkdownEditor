using Avalonia.Controls;
using MarkdownEditor.ViewModels.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownEditor.Views.Controls;

public partial class MarkdownEditorView : UserControl
{
    public MarkdownEditorView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<MarkdownEditorViewModel>();
    }
}