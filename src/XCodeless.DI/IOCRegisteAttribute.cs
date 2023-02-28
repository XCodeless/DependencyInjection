using Microsoft.Extensions.DependencyInjection;
using System;

namespace XCodeless.DI;

/// <summary>
/// <para>注入到容器 抽象类型选用<see cref="IOCRegisteAttribute{TService}"/></para>
/// <para>p.s. 需配合其它组件完成注入功能</para>
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class IOCRegisteAttribute : Attribute
{
    /// <param name="lifetime">生命周期</param>
    public IOCRegisteAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient) { Lifetime = lifetime; }
    public ServiceLifetime Lifetime { get; private set; } = ServiceLifetime.Transient;
}