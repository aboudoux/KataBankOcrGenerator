using System;
using KataBankOcrGenerator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataBankOcrGenerator.Tests
{
    [TestClass]
    public class ArgumentParserShoud
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentParserException))]
        public void ThrowErrorIfNoArgument() 
        {
            var parser = new ArgumentParser(new string[]{});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentParserException))]
        public void ThrowErrorIfOneArgument()
        {
            var parser = new ArgumentParser(new[] {"-G" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentParserException))]
        public void ThrowErrorIfUnknowOption() {
            var parser = new ArgumentParser(new[] { "B", "B" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentParserException))]
        public void ThrowErrorIfFirstArgumentNotANumber() {
            var parser = new ArgumentParser(new[] { "-G", "B" });
        }

        [TestMethod]
        public void SelectOptionG()
        {
            var parser = new ArgumentParser(new[] { "-G", "10" });
            Assert.AreEqual(Option.Generate, parser.SelectedOption);
            Assert.AreEqual(10, parser.FirstOptionArgument);
        }

        [TestMethod]
        public void SelectOptionV() {
            var parser = new ArgumentParser(new[] { "-V", "10" });
            Assert.AreEqual(Option.Validate, parser.SelectedOption);
            Assert.AreEqual(10, parser.FirstOptionArgument);
        }

        [TestMethod]
        public void SelectOptionC() {
            var parser = new ArgumentParser(new[] { "-C", "10" });
            Assert.AreEqual(Option.Convert, parser.SelectedOption);
            Assert.AreEqual(10, parser.FirstOptionArgument);
        }

        [TestMethod]
        public void SelectOptionK() {
            var parser = new ArgumentParser(new[] { "-K", "10" });
            Assert.AreEqual(Option.Key, parser.SelectedOption);
            Assert.AreEqual(10, parser.FirstOptionArgument);
        }
        
    }
}
