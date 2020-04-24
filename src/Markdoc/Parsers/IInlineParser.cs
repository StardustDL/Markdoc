using Markdoc.Documents;

namespace Markdoc.Parsers
{
    public interface IInlineParser<TObject> : IParser<TObject> where TObject : DocumentObject
    {
    }
}
