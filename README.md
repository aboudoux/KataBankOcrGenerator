# KataBankOcrGenerator
This tool is developed for generate some account numbers for the KataBank OCR -> http://codingdojo.org/kata/BankOCR/

# Usage

    KataBankOcrGenerator.exe [Option] (arguments)
    
    Options are
    -G (count)  : Generate some valid account number in 7segment format
    -V (number) : Validate an account number
    -C (number) : Convert the account number in 7Segment
    -K (number) : compute the Key to 8 digit account Number


# Tips

For generate some valid numbers in a file, use the '>' in the command line like follow :

    KataBankOcrGenerator.exe -G 10 > accounts.txt



