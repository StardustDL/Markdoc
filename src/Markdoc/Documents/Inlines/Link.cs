using Markdoc.Documents.Blocks;
using System;

namespace Markdoc.Documents.Inlines
{
    public class Link : InlineObject
    {
        public Link(string url, RawBlock? label = null)
        {
            Label = label;
            Url = url;
        }

        public RawBlock? Label { get; set; }

        public string Url { get; set; }
    }
}
