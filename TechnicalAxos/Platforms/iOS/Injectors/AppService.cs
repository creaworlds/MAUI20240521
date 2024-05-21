namespace TechnicalAxos;
public class AppService
{
    public string GetApplicationName() => Foundation.NSBundle.MainBundle.BundleIdentifier;
}