using Markdoc.Documents;
using Markdoc.Documents.Blocks;
using Markdoc.Renderers.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Test.Base
{
    [TestClass]
    public class HtmlRendererTest
    {
        [TestMethod]
        public async Task Break()
        {
            Document doc = new Document();
            doc.Body.Add(new Break());

            HtmlRenderer render = new HtmlRenderer();
            var result = await render.Render(doc);
            Assert.IsTrue(result.QuerySelector("br") != null);
        }
    }
}
