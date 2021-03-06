﻿using Markdoc.Documents.Inlines;
using System.Collections.Generic;

namespace Markdoc.Documents.Blocks
{
    public class Paragraph : BlockObject
    {
        public Paragraph()
        {

        }

        public Paragraph(string text) : this()
        {
            Content.Add(new Text(text));
        }

        public Paragraph(params InlineObject[] inlines) : this()
        {
            foreach (var v in inlines)
                Content.Add(v);
        }

        public IList<InlineObject> Content { get; } = new List<InlineObject>();
    }
}
