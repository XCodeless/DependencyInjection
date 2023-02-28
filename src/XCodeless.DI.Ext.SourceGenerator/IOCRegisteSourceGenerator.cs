using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace XCodeless.DI.Ext.SourceGenerator;

[Generator]
public class IOCRegisteSourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
#if DEBUG
        //System.Diagnostics.Debugger.Launch();
#endif
        context.RegisterForSyntaxNotifications(() => new IOCRegisteAttributeSyntaxReceiver());
    }

    const string template = """
using Microsoft.Extensions.DependencyInjection;
using XCodeless.DI;

namespace {0};
public static class IOCRegisteExtension
{{
    /// <summary>
    /// <para>根据特性<see cref="IOCRegisteAttribute"/>或<see cref="IOCRegisteAttribute{{TImpl}}"/>注入到容器</para>
    /// <para>由XCodeless.DI.Ext.SourceGenerator包编译时生成 生成时间:{2}</para>
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection RegistePreLabelTypes(this IServiceCollection services)
    {{
        {1}
        return services;
    }}
}}
""";
    public void Execute(GeneratorExecutionContext context)
    {
#if DEBUG
        //System.Diagnostics.Debugger.Launch();
#endif
        var attributeSyntaxReceiver = (IOCRegisteAttributeSyntaxReceiver)context.SyntaxReceiver;
        var attributeSyntaxes = attributeSyntaxReceiver.AttributeSyntaxes;
        if (!attributeSyntaxes.Any()) return;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var attributeSyntax in attributeSyntaxReceiver.AttributeSyntaxes)
        {
            string service = null;
            var genericTypeArguments = attributeSyntax.ChildNodes().OfType<GenericNameSyntax>().FirstOrDefault()?.ChildNodes()?.OfType<TypeArgumentListSyntax>()?.FirstOrDefault();
            if (genericTypeArguments != null)
            {
                service = genericTypeArguments.Arguments.FirstOrDefault().ToString();
            }
            var classDecSyntax = attributeSyntax.FirstAncestorOrSelf<ClassDeclarationSyntax>();
            var namespaceDecSyntax = classDecSyntax.FirstAncestorOrSelf<BaseNamespaceDeclarationSyntax>();
            var impl = (namespaceDecSyntax == null ? null : namespaceDecSyntax.Name + ".") + classDecSyntax?.Identifier.ValueText;
            string lifetime = nameof(ServiceLifetime.Transient);
            if (attributeSyntax.ArgumentList != null)
            {
                var lifeTimeSyntax = attributeSyntax.ArgumentList.Arguments.FirstOrDefault();
                var lifeTimeExpression = lifeTimeSyntax?.Expression as MemberAccessExpressionSyntax;
                if (lifeTimeExpression != null) lifetime = lifeTimeExpression?.Name?.Identifier.ValueText;
            }
            switch (lifetime)
            {
                case nameof(ServiceLifetime.Singleton):
                    stringBuilder.Append($"services.{nameof(ServiceCollectionServiceExtensions.AddSingleton)}");
                    break;
                case nameof(ServiceLifetime.Scoped):
                    stringBuilder.Append($"services.{nameof(ServiceCollectionServiceExtensions.AddScoped)}");
                    break;
                case nameof(ServiceLifetime.Transient):
                    stringBuilder.Append($"services.{nameof(ServiceCollectionServiceExtensions.AddTransient)}");
                    break;
            }
            stringBuilder.Append("<");
            if (!string.IsNullOrWhiteSpace(service)) stringBuilder.Append($"{service}, ");
            stringBuilder.AppendLine($"{impl}>();");
        }
        var source = string.Format(template, context.Compilation.Assembly.Name, stringBuilder.ToString(), DateTime.Now.ToString("F", System.Globalization.CultureInfo.GetCultureInfo("zh-cn")));
        string extensionTextFormatted = CSharpSyntaxTree.ParseText(source, (CSharpParseOptions)context.ParseOptions).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();
        context.AddSource("TestSourceGenerator.g.cs", extensionTextFormatted);
    }
}
