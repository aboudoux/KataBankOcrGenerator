using System;
using System.Collections.Generic;
using KataBankOcrGenerator.Exceptions;

namespace KataBankOcrGenerator
{
    public class ArgumentParser
    {
        private readonly Dictionary<string, Option> _optionsDictionary = new Dictionary<string, Option>()
        {
            {"-G", Option.Generate},
            {"-V", Option.Validate},
            {"-C", Option.Convert},
            {"-K", Option.Key }
        };


        public ArgumentParser(string[] args)
        {
            if( args.Length != 2 )
                Usage();

            var firstArg = args[0].ToUpper();
            if(!_optionsDictionary.ContainsKey(firstArg))                
                Usage();

            SelectedOption = _optionsDictionary[firstArg];

            int arg;
            if(!int.TryParse(args[1], out arg))
                Usage();
            FirstOptionArgument = arg;
        }

        public Option SelectedOption { get; }
        public int FirstOptionArgument { get; }
        

        private void Usage()
        {
            throw new ArgumentParserException("Usage : BankOcrTool.exe [Option] (arguments)" + Environment.NewLine + Environment.NewLine +
                                "Options are" + Environment.NewLine +
                                "-G (count)  : Generate some valid account number in 7segment format" + Environment.NewLine +
                                "-V (number) : Validate an account number" + Environment.NewLine +
                                "-C (number) : Convert the account number in 7Segment" + Environment.NewLine +
                                "-K (number) : compute the Key to 8 digit account Number" + Environment.NewLine
                );
        }
    }
}