using Avalonia.Controls;
using MarkdownEditor.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownEditor.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetRequiredService<MainViewModel>();
    }
}
