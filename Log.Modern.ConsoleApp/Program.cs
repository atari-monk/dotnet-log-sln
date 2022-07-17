using DIHelper;
using Log.Modern.ConsoleApp;
using Unity;

IBootstraper booter = new Bootstraper(
	new LogSuite(
		new UnityContainer()
			.AddExtension(
				new Diagnostic())));
booter.CreateApp();
booter.RunApp(args);