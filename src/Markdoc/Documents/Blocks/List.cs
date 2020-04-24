using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class List : BlockObject
    {
        public List()
        {
        }

        public List(bool isOrdered, params ListItem[] lis) : this()
        {
            IsOrdered = isOrdered;
            foreach (var v in lis) Items.Add(v);
        }

        public bool IsOrdered { get; set; }

        public IList<ListItem> Items { get; } = new List<ListItem>();
    }
}
