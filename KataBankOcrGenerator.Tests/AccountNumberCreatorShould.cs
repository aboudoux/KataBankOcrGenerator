using System;
using KataBankOcrGenerator.Digits;
using KataBankOcrGenerator.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataBankOcrGenerator.Tests
{
    [TestClass]
    public class AccountNumberCreatorShould
    {
        [TestMethod]
        [ExpectedException(typeof (IncorrectAccountNumberException))]
        public void ThrowExceptionIfMoreThanDigit()
        {
            var accountNumber = new SevenSegmentAccountNumber(1234567897);
        }

        [TestMethod]
        public void NotThrowExceptionIfLessThan9Digit()
        {
            var accountNumber = new SevenSegmentAccountNumber(25);
        }

        [TestMethod]
        public void GenerateAll0()
        {
            var accountNumber = new SevenSegmentAccountNumber(0);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n" + "| || || || || || || || || |\r\n" +
                "|_||_||_||_||_||_||_||_||_|\r\n", result);
        }

        [TestMethod]
        public void GenerateAll1()
        {
            var accountNumber = new SevenSegmentAccountNumber(111111111);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                "                           \r\n" + " |  |  |  |  |  |  |  |  | \r\n" +
                " |  |  |  |  |  |  |  |  | \r\n", result);
        }

        [TestMethod]
        public void GenerateAll2()
        {
            var accountNumber = new SevenSegmentAccountNumber(222222222);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n _| _| _| _| _| _| _| _| _|\r\n|_ |_ |_ |_ |_ |_ |_ |_ |_ \r\n", result);
        }

        [TestMethod]
        public void GenerateAll3()
        {
            var accountNumber = new SevenSegmentAccountNumber(333333333);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n _| _| _| _| _| _| _| _| _|\r\n _| _| _| _| _| _| _| _| _|\r\n", result);
        }

        [TestMethod]
        public void GenerateAll4()
        {
            var accountNumber = new SevenSegmentAccountNumber(444444444);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                "                           \r\n|_||_||_||_||_||_||_||_||_|\r\n  |  |  |  |  |  |  |  |  |\r\n", result);
        }

        [TestMethod]
        public void GenerateAll5()
        {
            var accountNumber = new SevenSegmentAccountNumber(555555555);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n|_ |_ |_ |_ |_ |_ |_ |_ |_ \r\n _| _| _| _| _| _| _| _| _|\r\n", result);
        }

        [TestMethod]
        public void GenerateAll6()
        {
            var accountNumber = new SevenSegmentAccountNumber(666666666);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                "                           \r\n|_ |_ |_ |_ |_ |_ |_ |_ |_ \r\n|_||_||_||_||_||_||_||_||_|\r\n", result);
        }

        [TestMethod]
        public void GenerateAll7()
        {
            var accountNumber = new SevenSegmentAccountNumber(777777777);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n  |  |  |  |  |  |  |  |  |\r\n  |  |  |  |  |  |  |  |  |\r\n", result);
        }

        [TestMethod]
        public void GenerateAll8()
        {
            var accountNumber = new SevenSegmentAccountNumber(888888888);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n|_||_||_||_||_||_||_||_||_|\r\n|_||_||_||_||_||_||_||_||_|\r\n", result);
        }

        [TestMethod]
        public void GenerateAll9()
        {
            var accountNumber = new SevenSegmentAccountNumber(999999999);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                " _  _  _  _  _  _  _  _  _ \r\n|_||_||_||_||_||_||_||_||_|\r\n _| _| _| _| _| _| _| _| _|\r\n", result);
        }

        [TestMethod]
        public void GenerateAccountWithAllNumber()
        {
            var accountNumber = new SevenSegmentAccountNumber(123456789);
            var result = accountNumber.ToString();
            Assert.AreEqual(
                "    _  _     _     _  _  _ \r\n |  _| _||_||_ |_   ||_||_|\r\n | |_  _|  | _||_|  ||_| _|\r\n", result);
        }

        [TestMethod]
        public void GenerateAccountWithAllNumberReverse()
        {
            var accountNumber = new SevenSegmentAccountNumber(987654321);
            var result = accountNumber.ToString();
            Assert.AreEqual(" _  _  _     _     _  _    \r\n|_||_|  ||_ |_ |_| _| _| | \r\n _||_|  ||_| _|  | _||_  | \r\n", result);
        }

        [TestMethod]
        public void GenerateAccountNumberRandomWith0()
        {
            var accountNumber = new SevenSegmentAccountNumber(510400596);
            var result = accountNumber.ToString();
            Assert.AreEqual(" _     _     _  _  _  _    \r\n|_  | | ||_|| || ||_ |_||_ \r\n _| | |_|  ||_||_| _| _||_|\r\n", result);
        }

        [TestMethod]
        public void ValidateAccountNumber1()
        {
            Assert.IsTrue(AccountNumberHelper.IsValid(345882865));
        }

        [TestMethod]
        public void ValidateAccountNumber2() {
            Assert.IsTrue(AccountNumberHelper.IsValid(457508000));
        }

        [TestMethod]
        public void ValidateAccountNumber3() {
            Assert.IsTrue(AccountNumberHelper.IsValid(490867715));
        }


        [TestMethod]
        public void NotValidateInvalidAccountNumber()
        {
            Assert.IsFalse(AccountNumberHelper.IsValid(445869873));
        }

        [TestMethod]
        public void GenerateValidAccountNumber()
        {
            var number = AccountNumberHelper.GetRandomValidAccountNumber();
            Assert.IsTrue(AccountNumberHelper.IsValid(number));
        }

        [TestMethod]
        public void AdaptKey11()
        {
            var ok = AccountNumberHelper.CreateNumberWithControlKey(99999999);
            Assert.IsTrue(AccountNumberHelper.IsValid(int.Parse(ok)));
        }

        [TestMethod]
        [ExpectedException(typeof(IncorrectKeyComputation))]
        public void AdaptKey10() {
            var ok = AccountNumberHelper.CreateNumberWithControlKey(99999994);
            Assert.IsTrue(AccountNumberHelper.IsValid(int.Parse(ok)));
        }
    }    
}
