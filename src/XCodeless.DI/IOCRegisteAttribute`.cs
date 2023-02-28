using Microsoft.Extensions.DependencyInjection;

namespace XCodeless.DI;

/// <summary>
/// <para>注入到容器</para>
/// <para>p.s. 需配合其它组件完成注入功能</para>
/// </summary>
/// <typeparam name="TService">注册的类型</typeparam>
public class IOCRegisteAttribute<TService> : IOCRegisteAttribute
{
    /// <param name="lifetime">生命周期</param>
    public IOCRegisteAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient) : base(lifetime) { }
}