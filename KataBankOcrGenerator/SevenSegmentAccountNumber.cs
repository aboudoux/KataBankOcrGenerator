using System.Collections.Generic;
using System.Text;
using KataBankOcrGenerator.Digits;
using KataBankOcrGenerator.Exceptions;

namespace KataBankOcrGenerator
{
    public class SevenSegmentAccountNumber
    {
        private readonly Dictionary<char, I7SegmentDigit> _digitDictionary = new Dictionary<char, I7SegmentDigit>()
        {
            {'0', new Digit0() },
            {'1', new Digit1() },
            {'2', new Digit2() },
            {'3', new Digit3() },
            {'4', new Digit4() },
            {'5', new Digit5() },
            {'6', new Digit6() },
            {'7', new Digit7() },
            {'8', new Digit8() },
            {'9', new Digit9() },
        };
        private readonly string _accountNumber;

        public SevenSegmentAccountNumber(int accountNumber)
        {
            _accountNumber = accountNumber.ToString("000000000");
            if(_accountNumber.Length > 9 )
                throw new IncorrectAccountNumberException();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var digit in _accountNumber)
                result.Append(_digitDictionary[digit].FirstLine);
            result.AppendLine();
            foreach (var digit in _accountNumber)
                result.Append(_digitDictionary[digit].SecondLine);
            result.AppendLine();
            foreach (var digit in _accountNumber)
                result.Append(_digitDictionary[digit].ThirdLine);
            result.AppendLine();

            return result.ToString();
        }        
    }
}