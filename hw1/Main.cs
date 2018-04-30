// AUTHOR: Jonathan Ho
// FILENAME: Main.cs
// DATE: April 27, 2018
// REVISION HISTORY: v1 - PA#1 Class Design
//                   v2 - PA#2 Implementation

using System;

namespace EncryptWordApplication
{
    class Mainclass
    {
 
        static void Main(string[] args)
        {
            Console.WriteLine("INSTRUCTIONS: This is a demonstration of the guessing game for elmentary school kids. Users are not reqired to enter any guesses as all inputs are generated or pre-defined. You will see multiple games here. 1st game will test the warning message when the input is less than 4 characters. 2nd to 5th games will test when the input is a combination of alphabets, special characters and/or numbers. Special characters and numbers are ignored and only the alphabets will be encrpted. The 6th game will test using random computed guesses to test the stat returns correctly. The 7th game will test the game which can be reset at any time, stat will display to show the game has been reset.\n\nEXPLANATION: The stat will display when the guess is correct. Count is the total count of attempts. Sum is the total sum of the guess values. Avg is the average values of the guess values. Low is the count of the guesses lower than encrpyted shift number. High is the count of the guesses higher than the encrypted shift number. \n\n");

            EncryptWordDriver.Test("abc");
            // Testing the warning message when the input is less than 4 characters

            EncryptWordDriver.Test("abcABC"); // testing a regular string
            EncryptWordDriver.Test("abcABC!!!!!"); // testing a regular string with special characters
            EncryptWordDriver.Test("ABCabc1111"); // testing a regular string with numbers
            EncryptWordDriver.Test("ABCabc1111@@@@"); // testing a regular string with numbers and special characters

            EncryptWordDriver.Randomtest("Jonathan"); // testing using a random computed guess to test the high and low guesses count

            EncryptWordDriver.Resettest("Seattle"); // description: testing the RESET will reset the game

        }

    }
}
