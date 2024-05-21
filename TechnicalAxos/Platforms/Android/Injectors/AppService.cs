namespace TechnicalAxos;
public class AppService
{
    public string GetApplicationName() => Android.App.Application.Context.PackageName ?? string.Empty;
}