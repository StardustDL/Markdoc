using Markdoc.Documents;
using Markdoc.Documents.Blocks;
using Markdoc.Documents.Inlines;
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
        async Task<AngleSharp.Dom.IDocument> Render(Document doc)
        {
            HtmlRenderer render = new HtmlRenderer();
            var result = await render.Render(doc);
            Console.WriteLine(result.DocumentElement.OuterHtml);
            return result;
        }

        [TestMethod]
        public async Task Break()
        {
            Document doc = new Document();
            doc.Body.Add(new Break());

            var result = await Render(doc);

            Assert.IsTrue(result.QuerySelector("br") != null);
        }

        [TestMethod]
        public async Task CodeBlock()
        {
            Document doc = new Document();
            doc.Body.Add(new CodeBlock("text"));

            var result = await Render(doc);

            Assert.AreEqual("text", result.QuerySelector("pre code").TextContent);
        }

        [TestMethod]
        public async Task Paragraph()
        {
            Document doc = new Document();
            var block = new Paragraph("text");
            doc.Body.Add(block);

            var result = await Render(doc);

            Assert.AreEqual("text", result.QuerySelector("p").TextContent);
        }

        [TestMethod]
        public async Task Header()
        {
            Document doc = new Document();
            var block = new Header(1, new Paragraph("text"));
            doc.Body.Add(block);

            var result = await Render(doc);

            Assert.AreEqual("text", result.QuerySelector("h1").TextContent);
        }

        [TestMethod]
        public async Task List()
        {
            Document doc = new Document();

            doc.Body.Add(new List(false, new ListItem("ul1"), new ListItem("ul2")));
            doc.Body.Add(new List(true, new ListItem("ol1"), new ListItem("ol2")));

            var result = await Render(doc);

            {
                var lis = result.QuerySelectorAll("ul li");
                Assert.IsTrue(lis.Length == 2);
                Assert.AreEqual("ul1", lis[0].TextContent);
                Assert.AreEqual("ul2", lis[1].TextContent);
            }
            {
                var lis = result.QuerySelectorAll("ol li");
                Assert.IsTrue(lis.Length == 2);
                Assert.AreEqual("ol1", lis[0].TextContent);
                Assert.AreEqual("ol2", lis[1].TextContent);
            }
        }

        [TestMethod]
        public async Task Text()
        {
            Document doc = new Document();
            doc.Body.Add(new RawBlock(new Text("text")));

            var result = await Render(doc);

            Assert.AreEqual("text", result.Body.TextContent);
        }

        [TestMethod]
        public async Task CodeSpan()
        {
            Document doc = new Document();
            doc.Body.Add(new RawBlock(new CodeSpan("text")));

            var result = await Render(doc);

            Assert.AreEqual("text", result.QuerySelector("code").TextContent);
        }

        [TestMethod]
        public async Task Link()
        {
            Document doc = new Document();
            doc.Body.Add(new RawBlock(new Link("localhost", new RawBlock("lh"))));

            var result = await Render(doc);

            var a = result.QuerySelector("a");
            Assert.AreEqual("localhost", a.GetAttribute("href"));
            Assert.AreEqual("lh", result.QuerySelector("a").TextContent);
        }

        [TestMethod]
        public async Task Image()
        {
            Document doc = new Document();
            doc.Body.Add(new RawBlock(new Image("localhost", "lh")));

            var result = await Render(doc);

            var a = result.QuerySelector("img");
            Assert.AreEqual("localhost", a.GetAttribute("src"));
            Assert.AreEqual("lh", a.GetAttribute("alt"));
        }
    }
}
