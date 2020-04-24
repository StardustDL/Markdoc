using Markdoc.Documents.Blocks;
using System;

namespace Markdoc.Documents.Inlines
{
    public class Image : InlineObject
    {
        public Image(string url, string alt = "")
        {
            Alt = alt;
            Url = url;
        }

        public string Alt { get; set; }

        public string Url { get; set; }
    }
}
