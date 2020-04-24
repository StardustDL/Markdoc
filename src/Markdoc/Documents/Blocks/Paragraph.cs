using Markdoc.Documents.Inlines;
using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class Paragraph : BlockObject
    {
        public IList<InlineObject> Content { get; } = new List<InlineObject>();
    }
}
