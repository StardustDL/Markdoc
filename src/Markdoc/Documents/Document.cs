using Markdoc.Documents.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Markdoc.Documents
{
    public class Document : DocumentObject
    {
        public Document()
        {
            Body = new List<BlockObject>();
        }

        public IList<BlockObject> Body { get; }
    }
}
