// AUTHOR: Jonathan Ho
// FILENAME: Driver.cs
// DATE: April 27, 2018
// REVISION HISTORY: v1 - PA#1 Class Design
//                   v2 - PA#2 Implementation
// 
// This class is the driver of the EncrpytWord This program targets to elementary school students. 
// Students make guesses to find out the correct number of  alphabet shift used to encrypt the word 
// they entered. The word is encrypted using the Caesar cipher shift. For example, the letter 'a' will 
// be encrypted as 'd' when the shift value is 3. Students ask the program to encode the words. Then, 
// the student will be asked for their guesses of the shift. The program will record  the statistics 
// until a guess is correct. It records the number of attempts, count of high guesses, low guesses and 
// the average guess value. EncryptedWord contains processes:
// 
// 1) Encrypt(string) - returns the encrypted word using the computed shift number
// 2) Guess(int) - returns if the guess matches the computed shift number
// 3) Reset() - resets the guessing game at any time
// 4) Print(EncryptWord) - prints out the stats of the current game

// Assumptions:
// input: predefined or generated
// source of input: n/a
// Encrypt(string): input should be longer than 4 characters or the game will not start (you should throw an error message)
//                  input cannot be used on an already encrypted word
//					input cannot contains only numbers or only special characters
//					input must contains alphabets with combination of numbers and special characters 
// Guess(int) - the guess should be between 1 to 25 as the alphabet has only 26 characters (any integar will be accepted)
// Reset() can be called at any time
// Print() can be called at any time

using System;

namespace EncryptWordApplication
{
    class EncryptWordDriver
    {
        // description: prints out the stats of the current game
        public static void Print(EncryptWord r)
        {
            double avg = 0;
            if (r.GetSum() == 0 && r.GetCount() == 0)
            {
                avg = 0;
            }
            else
            {
                avg = r.GetSum() / (double) r.GetCount();
            }
            Console.WriteLine("Stats: Count: " + r.GetCount() + ", ");
            Console.WriteLine("Sum: " + r.GetSum() + ", ");
            Console.WriteLine("Avg: " + avg + ", ");
            Console.WriteLine("Count of Low guesses is " + r.Getlow() + ", ");
            Console.WriteLine("Count of High guesses is " + r.Gethigh());
        }

        // description: guesses will always start from 1 to 25, it will stop until the guess is correct
        // input:  input should be longer than 4 characters or the game will not start (you should throw an error message)
        //         input cannot be used on an already encrypted word
        //		   input cannot contains only numbers or only special characters
        //		   input must contains alphabets with combination of numbers and special characters 
        // output: Game will stop until the random computed guess matches the correct number of shifts and stats will return
        public static void Test(string input)
        {
            Console.WriteLine("Welcome to the guessing game using Caeser Cipher Shift! You are trying to guess the secret number of the alphabet shifts.");
            if (input.Length < 4)
            {
                Console.WriteLine("ERROR: The input must be longer or equal than 4 characters. Try again!");
            }
            else
            {
                EncryptWord e1 = new EncryptWord();
                Console.WriteLine("The encrpyted word is " + e1.Encrypt(input));
                for (int i = 1; i < 26; i++)
                {
                    if (e1.Guess(i))
                    {
                        Console.WriteLine("Your guess is " + i + " and the original word is " + e1.Decrypt() + ". Correct!");
                        Print(e1);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your guess is " + i + ". Try again!");
                    }
                }
            }
            Console.WriteLine("Desired output: Game will stop until the random computed guess matches the correct number of shifts and stats will return");
            Console.WriteLine("**********************************************");
        }

        // description: guesses will be computed using a random number (1 to 25), it will stop until the guess is correct
        // input:  input should be longer than 4 characters or the game will not start (you should throw an error message)
        //         input cannot be used on an already encrypted word
        //		   input cannot contains only numbers or only special characters
        //		   input must contains alphabets with combination of numbers and special characters 
        // output: Game will stop until the random computed guess matches the correct number of shifts and stats will return
        public static void Randomtest(string input)
        {
            Console.WriteLine("Welcome to the guessing game using Caeser Cipher Shift! You are trying to guess the secret number of the alphabet shifts.");
            if (input.Length < 4)
            {
                Console.WriteLine("ERROR: The input must be longer or equal than 4 characters. Try again!");
                Console.WriteLine("**********************************************\n");
            }
            else
            {
                EncryptWord e1 = new EncryptWord();
                Console.WriteLine("The encrpyted word is " + e1.Encrypt(input));
                Random rnd = new Random();
                int i = rnd.Next(1, 25);
                Console.WriteLine("Your guess is " + i + ". ");

                while (!(e1.Guess(i)))
                {
                    Console.WriteLine("Try again! ");
                    i = rnd.Next(1, 25);
                    Console.WriteLine("Your guess is " + i + ".");
                };
                Console.WriteLine("Your guess is " + i + " and the original word is " + e1.Decrypt() + ". Correct!");

                Print(e1);
            }
            Console.WriteLine("Desired output: Game will stop until the random computed guess matches the correct number of shifts and stats will return");
            Console.WriteLine("**********************************************");
        }

        // description: testing the RESET will reset the game and the stats
        // input:  input should be longer than 4 characters or the game will not start (you should throw an error message)
        //         input cannot be used on an already encrypted word
        //		   input cannot contains only numbers or only special characters
        //		   input must contains alphabets with combination of numbers and special characters 
        // output: Game is rest and the stats are reverted to zero.
        public static void Resettest(string input)
        {
            Console.WriteLine("Welcome to the guessing game using Caeser Cipher Shift! You are trying to guess the secret number of the alphabet shifts.");
            if (input.Length < 4)
            {
                Console.WriteLine("ERROR: The input must be longer or equal than 4 characters. Try again!");
                Console.WriteLine("**********************************************\n");
            }
            else
            {
                EncryptWord e1 = new EncryptWord();
                Console.WriteLine("The encrpyted word is " + e1.Encrypt(input));
                Console.WriteLine("Entering a guess for the encrypted nameshift: 10");
                e1.Guess(10);
                Console.WriteLine(e1);
                Console.WriteLine("Sorry! I am going to reset the game!");
                e1.Reset();
                Print(e1);
            }
            Console.WriteLine("Desired output: Stats are reverted to zero.");
            Console.WriteLine("**********************************************");
        }


    }
}
