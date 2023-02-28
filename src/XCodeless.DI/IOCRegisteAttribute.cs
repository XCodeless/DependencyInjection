using Microsoft.Extensions.DependencyInjection;
using System;

namespace XCodeless.DI;

/// <summary>
/// <para>ע�뵽���� ��������ѡ��<see cref="IOCRegisteAttribute{TService}"/></para>
/// <para>p.s. ���������������ע�빦��</para>
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class IOCRegisteAttribute : Attribute
{
    /// <param name="lifetime">��������</param>
    public IOCRegisteAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient) { Lifetime = lifetime; }
    public ServiceLifetime Lifetime { get; private set; } = ServiceLifetime.Transient;
}