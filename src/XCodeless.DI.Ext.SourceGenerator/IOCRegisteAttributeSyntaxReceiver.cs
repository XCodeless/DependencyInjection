using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace XCodeless.DI.Ext.SourceGenerator;

internal class IOCRegisteAttributeSyntaxReceiver : ISyntaxReceiver
{
    public List<AttributeSyntax> AttributeSyntaxes { get; } = new List<AttributeSyntax>();
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is AttributeSyntax attrSyntax && attrSyntax.Name is IdentifierNameSyntax identifierName && identifierName.Identifier.ValueText.StartsWith("IOCRegiste"))
        {
            AttributeSyntaxes.Add(attrSyntax);
        }
    }
}