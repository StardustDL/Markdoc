using Markdoc.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom;
using AngleSharp;
using System.Threading.Tasks;
using Markdoc.Documents.Blocks;
using AngleSharp.Html.Dom;
using Markdoc.Documents.Inlines;

namespace Markdoc.Renderers.Html
{
    public class HtmlRenderer : IRenderer<IDocument>
    {
        INode RenderObject(IDocument document, InlineObject obj)
        {
            return obj switch
            {
                CodeSpan robj => RenderObject(document, robj),
                Image robj => RenderObject(document, robj),
                Link robj => RenderObject(document, robj),
                Text robj => RenderObject(document, robj),
                _ => throw new NotImplementedException(),
            };
        }

        INode RenderObject(IDocument document, BlockObject obj)
        {
            return obj switch
            {
                Break robj => RenderObject(document, robj),
                CodeBlock robj => RenderObject(document, robj),
                Header robj => RenderObject(document, robj),
                List robj => RenderObject(document, robj),
                ListItem robj => RenderObject(document, robj),
                Paragraph robj => RenderObject(document, robj),
                RawBlock robj => RenderObject(document, robj),
                _ => throw new NotImplementedException(),
            };
        }

        INode RenderObject(IDocument document, Text obj)
        {
            switch (obj.Style)
            {
                case TextStyle.Normal:
                    return document.CreateTextNode(obj.Content);
                case TextStyle.Emphasized:
                    {
                        var ele = document.CreateElement("em");
                        ele.TextContent = obj.Content;
                        return ele;
                    }
                case TextStyle.Strong:
                    {
                        var ele = document.CreateElement("strong");
                        ele.TextContent = obj.Content;
                        return ele;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        INode RenderObject(IDocument document, CodeSpan obj)
        {
            var ele = document.CreateElement("code");
            ele.TextContent = obj.Content;
            return ele;
        }

        INode RenderObject(IDocument document, Link obj)
        {
            var ele = document.CreateElement("a");
            ele.SetAttribute("href", obj.Url);
            if (obj.Label != null)
                ele.AppendChild(RenderObject(document, obj.Label));
            return ele;
        }

        INode RenderObject(IDocument document, Image obj)
        {
            var ele = document.CreateElement("img");
            ele.SetAttribute("src", obj.Url);
            ele.SetAttribute("alt", obj.Alt);
            return ele;
        }

        INode RenderObject(IDocument document, Break obj)
        {
            return document.CreateElement("br");
        }

        INode RenderObject(IDocument document, CodeBlock obj)
        {
            var ele = document.CreateElement("pre");
            var codeEle = document.CreateElement("code");
            codeEle.TextContent = obj.Content;
            ele.AppendElement(codeEle);
            return ele;
        }

        INode RenderObject(IDocument document, Paragraph obj)
        {
            var ele = document.CreateElement("p");
            foreach (var item in obj.Content)
            {
                ele.AppendChild(RenderObject(document, item));
            }
            return ele;
        }

        INode RenderObject(IDocument document, RawBlock obj)
        {
            var ele = document.CreateDocumentFragment();
            foreach (var item in obj.Content)
            {
                ele.AppendChild(RenderObject(document, item));
            }
            return ele;
        }

        INode RenderObject(IDocument document, ListItem obj)
        {
            var ele = document.CreateElement("li");
            foreach (var item in obj.Content)
            {
                ele.AppendChild(RenderObject(document, item));
            }
            return ele;
        }

        INode RenderObject(IDocument document, List obj)
        {
            IElement ele = obj.IsOrdered ? document.CreateElement("ol") : document.CreateElement("ul");
            foreach (var item in obj.Items)
            {
                ele.AppendChild(RenderObject(document, item));
            }
            return ele;
        }

        INode RenderObject(IDocument document, Header obj)
        {
            var ele = document.CreateElement($"h{obj.Level}");
            if (obj.Content != null)
                ele.AppendChild(RenderObject(document, obj.Content));
            return ele;
        }

        public async Task<IDocument> Render(Documents.Document document)
        {
            var context = new BrowsingContext();
            IDocument doc = await context.OpenNewAsync();

            foreach (var item in document.Body)
                doc.Body.AppendChild(RenderObject(doc, item));

            return doc;
        }
    }
}
