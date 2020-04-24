namespace Markdoc.Documents.Inlines
{
    public class CodeSpan : InlineObject
    {
        public CodeSpan(string content)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}
