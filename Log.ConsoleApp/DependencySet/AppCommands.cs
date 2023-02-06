using CLIFramework;
using CLIHelper;
using CLIReader;
using CLIWizardHelper;
using CRUDCommandHelper;
using Log.Console.Lib;
using Log.Data;
using Log.Wizard.Lib;
using ModelHelper;
using Serilog;
using Unity;
using Unity.Injection;

namespace Log.ConsoleApp;

public class AppCommands 
    : CLIFramework.AppCommands
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterCommands()
    {
        base.RegisterCommands();
        RegisterPlaceCommands();
        RegisterCategoryCommands();
    }

    private void RegisterPlaceCommands()
    {
        RegisterCommand<HelpCommand<Place>, Place>(
            "Help Place".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(IModelA.Name)
                , nameof(IModelA.Description)
            });

        Container.RegisterSingleton<IReadCommand<Place>, PlaceReadCmd>();

        RegisterCommand<PlaceReadCommand, Place>(
            "Place".ToLowerInvariant()
            , Container.Resolve<IReadCommand<Place>>());

        Container.RegisterSingleton<IInsertWizard<Place>, PlaceInsertWizard>(
            nameof(PlaceInsertWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            }));

        RegisterCommand<PlaceInsertCommand, Place>(
            "Insert Place".ToLowerInvariant()
            , Container.Resolve<IInsertWizard<Place>>(nameof(PlaceInsertWizard)));

        Container.RegisterSingleton<IUpdateWizard<Place>, PlaceUpdateWizard>(
            nameof(PlaceUpdateWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            }));

        RegisterCommand<PlaceUpdateCommand, Place>(
            "Update Place".ToLowerInvariant()
            , Container.Resolve<IUpdateWizard<Place>>(nameof(PlaceUpdateWizard)));
    }

    private void RegisterCategoryCommands()
    {
        RegisterCommand<HelpCommand<Category>, Category>(
            "Help Category".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(IModelA.Name)
                , nameof(IModelA.Description)
            });
        
        Container.RegisterSingleton<IReadCommand<Category>, CategoryReadCmd>();

        RegisterCommand<CategoryReadCommand, Category>(
            "Category".ToLowerInvariant()
            , Container.Resolve<IReadCommand<Category>>());

        Container.RegisterSingleton<IInsertWizard<Category>, CategoryInsertWizard>(
            nameof(CategoryInsertWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            }));

        RegisterCommand<CategoryInsertCommand, Category>(
            "Insert Category".ToLowerInvariant()
            , Container.Resolve<IInsertWizard<Category>>(
                nameof(CategoryInsertWizard)));

          Container.RegisterSingleton<IUpdateWizard<Category>, CategoryUpdateWizard>(
            nameof(CategoryUpdateWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            }));

        RegisterCommand<CategoryUpdateCommand, Category>(
            "Update Category".ToLowerInvariant()
            , Container.Resolve<IUpdateWizard<Category>>(nameof(CategoryUpdateWizard))
            );
    }
}