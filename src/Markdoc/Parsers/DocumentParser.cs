using Markdoc.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Markdoc.Parsers
{
    public class DocumentParser : IParser<Document>
    {
        Task<ParseResult<Document>> IParser<Document>.Parse(ParseInput input)
        {
            throw new NotImplementedException();
        }
    }
}
