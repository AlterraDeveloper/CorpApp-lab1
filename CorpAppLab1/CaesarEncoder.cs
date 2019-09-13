using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project
{
    public class CaesarEncoder
    {
        const int CRYPT_KEY = 24;
        const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";


        public static string Encrypt(string inputText, bool isReverse = false)
        {
            var outputText = string.Empty;
            var fullAlphabet = ALPHABET + ALPHABET.ToUpper();
            var fullAlphabetLength = fullAlphabet.Length;

            foreach (var ch in inputText)
            {
                var index = fullAlphabet.IndexOf(ch);
                if (index < 0)
                {
                    outputText += ch;
                }
                else
                {
                    if (isReverse)
                    {
                        outputText += fullAlphabet[(fullAlphabetLength + index - CRYPT_KEY) % fullAlphabetLength];
                    }
                    else
                    {
                        outputText += fullAlphabet[(fullAlphabetLength + index + CRYPT_KEY) % fullAlphabetLength];
                    }
                }
            }
            return outputText;
        }

    }
}
