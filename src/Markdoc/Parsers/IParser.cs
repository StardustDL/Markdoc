using Markdoc.Documents;
using System;
using System.Threading.Tasks;

namespace Markdoc.Parsers
{
    public interface IParser<TObject> where TObject : DocumentObject
    {
        Task<ParseResult<TObject>> Parse(ParseInput input);
    }
}
