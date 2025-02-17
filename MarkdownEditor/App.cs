using MarkdownEditor.Core.Interfaces;
using MarkdownEditor.Core.Services;
using MarkdownEditor.ViewModels;
using MarkdownEditor.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownEditor
{
    public partial class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<EditorView>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<IFileProvider, FileProvider>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
