using Markdoc.Documents.Blocks;
using System;

namespace Markdoc.Documents.Inlines
{
    public class Image : InlineObject
    {
        public Paragraph? Label { get; set; }

        public Uri? Uri { get; set; }
    }
}
