using Avalonia.Controls;
using MarkdownEditor.ViewModels.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownEditor.Views.Controls;

public partial class MarkdownPreviewView : UserControl
{
    public MarkdownPreviewView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<MarkdownPreviewViewModel>();
    }
}