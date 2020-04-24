using Markdoc.Diagnostics;

namespace Markdoc.Documents.Blocks
{
    public class Header : BlockObject
    {
        private int _level;

        public Header()
        {

        }

        public Header(int level, Paragraph? content = null) : this()
        {
            Level = level;
            Content = content;
        }

        public int Level
        {
            get => _level; set
            {
                if (value < 1) value = 1;
                if (value > 6) value = 6;
                _level = value;
            }
        }

        public Paragraph? Content { get; set; }
    }
}
