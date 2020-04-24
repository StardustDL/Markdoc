using Markdoc.Diagnostics;

namespace Markdoc.Documents.Blocks
{
    public class Header : BlockObject
    {
        private int _level;

        public int Level
        {
            get => _level; set
            {
                Assert.IsTrue(value > 0, $"{nameof(Level)} must be greater than 0.");
                _level = value;
            }
        }

        public string Content { get; set; } = string.Empty;
    }
}
