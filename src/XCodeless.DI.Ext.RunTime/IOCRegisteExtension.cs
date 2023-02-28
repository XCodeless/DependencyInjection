using XCodeless.DI;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

public static class IOCRegisteExtension
{

    /// <summary>
    /// 运行时根据特性<see cref="IOCRegisteAttribute"/>或<see cref="IOCRegisteAttribute{TImpl}"/>注入到容器
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegistePreLabelTypes(this IServiceCollection services)
    {
        var exportedTypes =
#if NETSTANDARD
            System.AppDomain.CurrentDomain.GetAssemblies()
#else
            System.Runtime.Loader.AssemblyLoadContext.Default.Assemblies
#endif 
           .Where(e => !e.IsDynamic).SelectMany(e => e.ExportedTypes
                             .Where(t => t.CustomAttributes.Any(attrData => attrData.AttributeType.Name.StartsWith(nameof(IOCRegisteAttribute))))).ToList();
        foreach (var registe in exportedTypes.Select(e => new { type = e, iocAttrs = e.GetCustomAttributes<IOCRegisteAttribute>() }))
        {
            foreach (var attr in registe.iocAttrs)
            {
                if (attr.TypeId is TypeInfo attrType && !attrType.IsGenericType)
                    services.Add(new ServiceDescriptor(registe.type, registe.type, attr.Lifetime));
                else
                {
                    var implType = attr.GetType().GetGenericArguments().First();
                    if (!implType.IsAssignableFrom(registe.type)) throw new Exception($"the type '{registe.type.FullName}' is not an implementation of '{implType.FullName}'");
                    services.Add(new ServiceDescriptor(implType, registe.type, attr.Lifetime));
                }
            }
        }
        return services;
    }
}
