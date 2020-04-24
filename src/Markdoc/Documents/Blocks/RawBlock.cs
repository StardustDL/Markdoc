using Markdoc.Documents.Inlines;
using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class RawBlock : BlockObject
    {
        public RawBlock()
        {

        }

        public RawBlock(string text) : this()
        {
            Content.Add(new Text(text));
        }

        public RawBlock(params InlineObject[] inlines) : this()
        {
            foreach (var v in inlines)
                Content.Add(v);
        }

        public IList<InlineObject> Content { get; } = new List<InlineObject>();
    }
}
