using IRepository;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.Loader;

namespace Runtime.Test;

[TestCaseOrderer("Runtime.Test.PriorityOrderer", "Runtime.Test")]
public class DITest
{
    IServiceCollection SC { get; }
    IServiceProvider SP { get; }
    public DITest()
    {
        SC = new ServiceCollection();
        SP = SC.RegistePreLabelTypes().BuildServiceProvider();
    }

    [Fact, TestPriority(1)]
    public void TransientObjTest()
    {
        Assert.Contains(SC, e => e.ServiceType == typeof(ITransientService) && e.Lifetime == ServiceLifetime.Transient);
        Assert.NotNull(SP.GetService<ITransientService>());

        Assert.Contains(SC, e => e.ServiceType == typeof(TransientService) && e.Lifetime == ServiceLifetime.Transient);
        Assert.NotNull(SP.GetService<TransientService>());

        Assert.Contains(SC, e => e.ServiceType == typeof(ITransientRepository) && e.Lifetime == ServiceLifetime.Transient);
        Assert.NotNull(SP.GetService<ITransientRepository>());

        Assert.Contains(SC, e => e.ServiceType == typeof(TransientRepository) && e.Lifetime == ServiceLifetime.Transient);
        Assert.NotNull(SP.GetService<TransientRepository>());
    }

    [Fact, TestPriority(2)]
    public void ScopedObjTest()
    {
        Assert.Contains(SC, e => e.ServiceType == typeof(IScopedService) && e.Lifetime == ServiceLifetime.Scoped);
        Assert.NotNull(SP.CreateScope().ServiceProvider.GetService<IScopedService>());

        Assert.Contains(SC, e => e.ServiceType == typeof(ScopedService) && e.Lifetime == ServiceLifetime.Scoped);
        Assert.NotNull(SP.CreateScope().ServiceProvider.GetService<ScopedService>());

        Assert.Contains(SC, e => e.ServiceType == typeof(IScopedRepository) && e.Lifetime == ServiceLifetime.Scoped);
        Assert.NotNull(SP.CreateScope().ServiceProvider.GetService<IScopedRepository>());

        Assert.Contains(SC, e => e.ServiceType == typeof(ScopedRepository) && e.Lifetime == ServiceLifetime.Scoped);
        Assert.NotNull(SP.CreateScope().ServiceProvider.GetService<ScopedRepository>());
    }

    [Fact, TestPriority(3)]
    public void SingletonObjTest()
    {
        Assert.Contains(SC, e => e.ServiceType == typeof(ISingletonService) && e.Lifetime == ServiceLifetime.Singleton);
        Assert.NotNull(SP.GetService<ISingletonService>());

        Assert.Contains(SC, e => e.ServiceType == typeof(SingletonService) && e.Lifetime == ServiceLifetime.Singleton);
        Assert.NotNull(SP.GetService<SingletonService>());

        Assert.Contains(SC, e => e.ServiceType == typeof(ISingletonRepository) && e.Lifetime == ServiceLifetime.Singleton);
        Assert.NotNull(SP.GetService<ISingletonRepository>());

        Assert.Contains(SC, e => e.ServiceType == typeof(SingletonRepository) && e.Lifetime == ServiceLifetime.Singleton);
        Assert.NotNull(SP.GetService<SingletonRepository>());
    }

    [Fact, TestPriority(4)]
    public void RegisteTypeWrongThrowObjTest()
    {
        AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppContext.BaseDirectory, "../../../RegisteWrong.dll"));
        Assert.ThrowsAny<Exception>(SC.RegistePreLabelTypes);
    }
}