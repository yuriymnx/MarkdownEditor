﻿using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Messaging;
using MarkdownEditor.Core.Interfaces;
using MarkdownEditor.Core.Services;
using MarkdownEditor.ViewModels;
using MarkdownEditor.ViewModels.Controls;
using MarkdownEditor.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MarkdownEditor;

public class App : Application
{
    private static ServiceProvider? _serviceProvider;
    public static ServiceProvider ServiceProvider { get => _serviceProvider ?? throw new NullReferenceException(); private set => _serviceProvider = value; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainViewModel>();
        services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
        services.AddSingleton<MarkdownEditorViewModel>();
        services.AddSingleton<MarkdownPreviewViewModel>();

        services.AddSingleton<IFileProvider, FileProvider>();

        ServiceProvider = services.BuildServiceProvider();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainViewModel>()
            };
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
