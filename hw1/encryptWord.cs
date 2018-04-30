// AUTHOR: Jonathan Ho
// FILENAME: EncryptWord.cs
// DATE: April 27, 2018
// REVISION HISTORY: v1 - PA#1 Class Design
//                   v2 - PA#2 Implementation
// DESCRIPTION: This guessing game targets to elementary school students.
// Students make guesses to find out the correct number of alphabet shift used to encrypt the word 
// they entered. The word is encrypted using the Caesar cipher shift. For example, the letter 'a' will 
// be encrypted as 'd'  when the shift value is 3. Program will ask students for a word and returns an encrpyed word. 
// Then, student will enter their guess of the shift and program returns if the guess is correct. The program records 
// the statistics until a guess is correct. It records the number of attempts, count of high guesses, low guesses and 
// the average guess value. EncryptedWord contains processes:
//
// 1) Encrypt(string) - returns encrypted word using the computed shift number
// 2) Guess(int) - returns if the guess matches the computed shift number
// 3) Reset() - resets the guessing game at any time
// 4) Print(EncryptWord) - prints out the stats of the current game

// Assumptions:
// Encrypt(string): input should be longer than 4 characters or the game will not start (you should throw an error message)
//                  input cannot be used on an already encrypted word
//                  input cannot contains only numbers or only special characters
//                  input must contains alphabets with combination of numbers and special characters 
// Guess(int) - the guess should be between 1 to 25 as the alphabet has only 26 characters (any integar will be accepted)


// Implementation Invariants: 
// Encrypt(string): after the EncryptWord is created, it can only be called once until the state of the EncryptWord object is reset (Reset() is called) 
//                  or off (Decrypt() is called)
// Guess(int) - can be used after Encrypt(string) is called and before Reset() is called
// Decrypt() - should be called after Encrypt() and/or Guess() is called
// Reset() can be called at anytime once the EncryptWord is created and should be called after Decrypt() is called
// GetCount(), GetSum(), Gethigh(), Getlow() should be used with a reference pointer of the EncryptWord objects and are intended as a helper method for Reset()

// State of the object:
// On: word has been encrypted
// Off: word has not been encrypted or decrypted
// Reset: Returns to its initial station, the word is ready to be encrypted

using System;

namespace EncryptWordApplication
{
    public class EncryptWord
    {
        private int count, sum, low, high;
        private int Shiftspace;
        private string word;

        // description: Constructor which initialize variables
        // precondition: an empty object
        // postcondition: an object with variables initialzied
        public EncryptWord()
        {
            word = "";
            count = 0;
            Shiftspace = 0;
            sum = 0;
            low = 0;
            high = 0;
        }

        // description: Encrypt returns an encrypted string by shifting each letter with a private number of places down the alphabet
        // pre: String has not been encrypted
        // post: String has been encrypted and cannot be re-encrypted
        public string Encrypt(string input)
        {
            string output = "";
            word = input;
            Random rnd = new Random();
            Shiftspace = rnd.Next(1, 25);
            for (int i = 0; i < input.Length; i++)
            {
                output += Cipher(input[i], Shiftspace);
            }
            return output;
        }

        // description: Guess returns true if the guessed number of shift is correct
        // pre: word has been encrypted
        // post: word has or has not been encrypted
        public bool Guess(int guess)
        {
            count++;
            sum += guess;
            if (guess > Shiftspace)
            {
                high++;
            }
            else if (guess < Shiftspace)
            {
                low++;
            }
            else
            {
                return true;   //return guess == shiftspace;
            }
            return false;
        }

        // description: Reset sets all variables to the initial state
        // pre: word cannot be encrypted or decrypted
        // post: word can be encrypted again as the object has been reset
        public void Reset()
        {
            Shiftspace = 0;
            count = 0;
            sum = 0;
            low = 0;
            high = 0;
            word = "";
        }

        // description: Decrypt returns the original word
        // pre: word has been encrypted
        // post: word has been decrypted and can be reset and show to users
        public string Decrypt()
        {
            return word;
        }

        // description: GetCount returns the count of the guess from private 
        public int GetCount()
        {
            return count;
        }

        // description: GetSum returns the sum of the guess from private 
        public int GetSum()
        {
            return sum;
        }

        // description: Getlow returns the count of the low guess (guess is smallar than number of alphabet shift) from private
        public int Getlow()
        {
            return low;
        }

        // description:Gethigh returns the count of the high guess (guess is larger than number of alphabet shift) from private
        public int Gethigh()
        {
            return high;
        }

        private static char Cipher(char ch, int key)
        {
            if (!Char.IsLetter(ch))
                return ch;

            char offset = Char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - offset) % 26) + offset);
        }



    } // end class
} // end namespace
