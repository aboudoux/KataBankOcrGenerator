using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KataBankOcrGenerator.Exceptions;
using static System.Console;

namespace KataBankOcrGenerator
{
    class Program
    {
        static void Main(string[] args) 
        {
            try
            {
                var arguments = new ArgumentParser(args);
                switch (arguments.SelectedOption) {
                    case Option.Generate:
                    {
                        for (int i = 0; i < arguments.FirstOptionArgument; i++)
                        {
                            var account = new SevenSegmentAccountNumber(AccountNumberHelper.GetRandomValidAccountNumber());
                            WriteLine(account.ToString());
                        }

                        break;
                    }

                   case Option.Convert:
                    {
                       var account = new SevenSegmentAccountNumber(arguments.FirstOptionArgument);
                       WriteLine(account);
                        break;
                    }

                    case Option.Validate:
                    {
                        WriteLine($"{args[1]} - Valid = {AccountNumberHelper.IsValid(arguments.FirstOptionArgument)}" );
                        break;
                    }

                    case Option.Key:
                    {
                        if( args[1].Length != 8 )                      
                            throw new Exception("Le numero de compte doit faire 8 digits");
                        WriteLine($"Number with checksum : {AccountNumberHelper.CreateNumberWithControlKey(arguments.FirstOptionArgument)}");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {                
                WriteLine(ex.Message);
            }
            
        }     
    }
}
