using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetArgs;

namespace DotNetArgsTests
{
    [TestClass]
    public class DefaultParserTest
    {
        [TestMethod]
        public void TestSimpleArgument()
        {
            var p = new DefaultParser();
            var args = p.Parse("123");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);
        }

        [TestMethod]
        public void TestSimpleArgumentUsingQuoteChar()
        {
            var p = new DefaultParser();
            p.QuoteChar = '`';
            var args = p.Parse("`123 456` 789 `123456`");
            Assert.AreEqual(3, args.Length);
            Assert.AreEqual("123 456", args[0]);
            Assert.AreEqual("789", args[1]);
            Assert.AreEqual("123456", args[2]);
        }

        [TestMethod]
        public void TestMultipleSimpleArguments()
        {
            var p = new DefaultParser();
            var args = p.Parse("123 456 789");
            Assert.AreEqual(3, args.Length);
            Assert.AreEqual("123", args[0]);
            Assert.AreEqual("456", args[1]);
            Assert.AreEqual("789", args[2]);
        }

        [TestMethod]
        public void TestSimpleValidQuote()
        {
            var p = new DefaultParser();
            var args = p.Parse("\"123\"");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);
        }

        [TestMethod]
        public void TestMultipleValidQuotes()
        {
            var p = new DefaultParser();
            var args = p.Parse("\"123\" \"456\"");
            Assert.AreEqual(2, args.Length);
            Assert.AreEqual("123", args[0]);
            Assert.AreEqual("456", args[1]);
        }

        [TestMethod]
        public void TestMultipleInvalidQuotes()
        {
            var p = new DefaultParser();
            var args = p.Parse("\"123\" \"456");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);
        }

        [TestMethod]
        public void TestWhitespaces()
        {
            var p = new DefaultParser();
            var args = p.Parse("   123");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);

            args = p.Parse("    123");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);

            args = p.Parse("123     ");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);

            args = p.Parse("123 ");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);

            args = p.Parse("    123 ");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);

            args = p.Parse("\n123   ");
            Assert.AreEqual(1, args.Length);
            Assert.AreEqual("123", args[0]);

            args = p.Parse("    123     456  789");
            Assert.AreEqual(3, args.Length);
            Assert.AreEqual("123", args[0]);
            Assert.AreEqual("456", args[1]);
            Assert.AreEqual("789", args[2]);
        }
    }
}
