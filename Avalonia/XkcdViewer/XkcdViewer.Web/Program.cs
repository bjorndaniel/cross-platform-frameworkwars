﻿using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.Web;
using System.Runtime.Versioning;
using XkcdViewer;

[assembly: SupportedOSPlatform("browser")]

internal partial class Program
{
    private static void Main(string[] args) => BuildAvaloniaApp()
        .UseReactiveUI()
        .SetupBrowserApp("out");

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>();
}