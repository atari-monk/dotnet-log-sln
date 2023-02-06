using DIHelper;
using Log.Modern.MDI.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;

IBootstraper booter = new Bootstraper(
	new MDIDependencySuite(
		new ServiceCollection()));
booter.CreateApp();
booter.RunApp(args);