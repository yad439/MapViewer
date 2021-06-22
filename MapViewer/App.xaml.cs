using System.Diagnostics;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace MapViewer {
	internal sealed partial class App {
		protected override void OnStartup(StartupEventArgs e) {
			base.OnStartup(e);

			var services = new ServiceCollection()
						   .AddSingleton<MainWindow>()
						   .AddSingleton<MapViewModel>()
						   .BuildServiceProvider();

			var mainWindow = services.GetService<MainWindow>();
			Debug.Assert(mainWindow != null, nameof(mainWindow) + " != null");
			mainWindow.Show();
			mainWindow.Loaded += (_, _) => MainWindow = mainWindow;
		}
	}
}