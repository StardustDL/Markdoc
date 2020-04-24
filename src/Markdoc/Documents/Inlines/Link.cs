using Markdoc.Documents.Blocks;
using System;

namespace Markdoc.Documents.Inlines
{
    public class Link : InlineObject
    {
        public Paragraph? Label { get; set; }

        public Uri? Uri { get; set; }
    }
}
