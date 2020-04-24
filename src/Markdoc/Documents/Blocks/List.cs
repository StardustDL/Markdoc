using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class List : BlockObject
    {
        public bool IsOrdered { get; set; }

        public IList<ListItem> Items { get; } = new List<ListItem>();
    }
}
