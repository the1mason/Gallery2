using Microsoft.Extensions.DependencyInjection;

namespace Gallery2;

public sealed class ApplicationContext
{
    public IServiceCollection Services { get; } = new ServiceCollection();
}