using Markdoc.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using AngleSharp.Dom;
using AngleSharp;
using System.Threading.Tasks;
using Markdoc.Documents.Blocks;
using AngleSharp.Html.Dom;

namespace Markdoc.Renderers.Html
{
    public class HtmlRenderer : IRenderer<IDocument>
    {
        public async Task<IDocument> Render(Documents.Document document)
        {
            var context = new BrowsingContext();
            IDocument result = await context.OpenNewAsync();

            foreach (var item in document.Body)
            {
                switch (item)
                {
                    case Break _:
                        result.Body.AppendElement(result.CreateElement<IHtmlBreakRowElement>());
                        break;
                }
            }

            return result;
        }
    }
}
