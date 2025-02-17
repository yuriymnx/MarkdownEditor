using MarkdownEditor.Core.Interfaces;
using MarkdownEditor.ViewModels.Base;

namespace MarkdownEditor.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IFileProvider _fileProvider;

    public MainViewModel(IFileProvider fileProvider)
    {
        _fileProvider = fileProvider;
    }

    public string Greeting => _fileProvider.Text;
}
