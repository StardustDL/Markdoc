using Markdoc.Documents;
using System;

namespace Markdoc.Parsers
{
    public interface IBlockParser<TObject> : IParser<TObject> where TObject : DocumentObject
    {
    }
}
