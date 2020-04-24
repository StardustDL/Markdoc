using Markdoc.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Base
{
    [TestClass]
    public class ParseInputTest
    {
        [TestMethod]
        public void Basic()
        {
            ParseInput input = new ParseInput(@"l1

l2
l3");
            Assert.AreEqual("l1", input.CurrentLine);
            Assert.AreEqual('l', input.CurrentChar);
            Assert.IsTrue(input.Move(1, 0));
            Assert.IsTrue(input.IsLineEnd());
            Assert.AreEqual(string.Empty, input.CurrentLine);
            Assert.IsNull(input.CurrentChar);
            Assert.AreEqual('l', input.NextChar());
            Assert.AreEqual("l3", input.NextLine());
            Assert.IsNull(input.NextLine());
            Assert.IsNull(input.NextChar());
            Assert.IsTrue(input.IsEnd());
        }
    }
}
