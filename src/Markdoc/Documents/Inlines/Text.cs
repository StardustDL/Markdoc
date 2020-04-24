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
        public Text(string content, TextStyle style = TextStyle.Normal)
        {
            Style = style;
            Content = content;
        }

        public TextStyle Style { get; set; }

        public string Content { get; set; }
    }
}
