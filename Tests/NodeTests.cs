using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ooui;

namespace Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TextState ()
        {
            var b = new Button ();
            Assert.AreEqual (1, b.StateMessages.Count);
            b.Text = "Hello";
            Assert.AreEqual (2, b.StateMessages.Count);
            b.Text = "Bye";
            Assert.AreEqual (2, b.StateMessages.Count);
        }

        [TestMethod]
        public void InsertBeforeOfRemovedNodeStillWorks ()
        {
            var p = new Div ();
            var c0 = new Span ();
            var c1 = new Span ();
            var c2 = new Span ();
            p.InsertBefore (c2, null);
            p.InsertBefore (c1, c2);
            p.InsertBefore (c0, c1);
            p.RemoveChild (c1);
            var ms = p.StateMessages;
            Assert.AreEqual (3, ms.Count);
            var c0s = (Array)ms[2].Value;
            Assert.AreEqual (2, c0s.Length);
            Assert.AreEqual (c0, c0s.GetValue (0));
            Assert.AreEqual (c2, c0s.GetValue (1));
        }
    }
}
