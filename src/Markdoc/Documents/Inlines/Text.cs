namespace Markdoc.Documents.Inlines
{
    public enum TextStyle
    {
        Normal,
        Emphasized,
        Strong
    }

    public class Text : InlineObject
    {
        public TextStyle Style { get; set; } = TextStyle.Normal;

        public string Content { get; set; } = string.Empty;
    }
}
