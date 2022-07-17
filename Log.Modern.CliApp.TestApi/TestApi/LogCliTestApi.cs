using DIHelper;
using Log.Data;
using Log.Modern.ConsoleApp;

namespace Log.Modern.CliApp.TestApi;

public abstract class LogCliTestApi
{
    protected LogBootstraper GetBooter()
    {
        var booter = new LogBootstraper();
        booter.CreateApp();
        return booter;
        throw new NotImplementedException();
    }

    protected ILogUnitOfWork GetUnitOfWork(
        LogBootstraper booter)
    {
        var unitOfWork = booter.Suite?.Resolve<ILogUnitOfWork>();
        ArgumentNullException.ThrowIfNull(unitOfWork);
        return unitOfWork;
    }

    public void RunCmd(
        IBootstraper booter
        , params string[] cmd)
    {
        booter.RunApp(cmd);
    }   
}