using Markdoc.Documents.Inlines;
using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class ListItem : BlockObject
    {
        public ListItem()
        {
        }

        public ListItem(string text) : this()
        {
            Content.Add(new RawBlock(new Text(text)));
        }

        public IList<BlockObject> Content { get; } = new List<BlockObject>();
    }
}
