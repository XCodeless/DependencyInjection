using Microsoft.Extensions.DependencyInjection;

namespace XCodeless.DI;

/// <summary>
/// <para>ע�뵽����</para>
/// <para>p.s. ���������������ע�빦��</para>
/// </summary>
/// <typeparam name="TService">ע�������</typeparam>
public class IOCRegisteAttribute<TService> : IOCRegisteAttribute
{
    /// <param name="lifetime">��������</param>
    public IOCRegisteAttribute(ServiceLifetime lifetime = ServiceLifetime.Transient) : base(lifetime) { }
}