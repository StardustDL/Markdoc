namespace Markdoc.Documents.Blocks
{
    public class CodeBlock : BlockObject
    {
        public CodeBlock(string content)
        {
            Content = content;
        }

        public string Content { get; set; } = string.Empty;
    }
}
