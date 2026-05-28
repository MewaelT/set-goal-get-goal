using Aspire.Hosting;

namespace ServiceDefaults;

public static class Extensions
{
    /// <summary>
    /// Adds the default Aspire services for the application
    /// </summary>
    public static IDistributedApplicationBuilder AddServiceDefaults(
        this IDistributedApplicationBuilder builder)
    {
        return builder;
    }
}
