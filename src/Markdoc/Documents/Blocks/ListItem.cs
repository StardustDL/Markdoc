using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class ListItem : BlockObject
    {
        public IList<BlockObject> Content { get; } = new List<BlockObject>();
    }
}
