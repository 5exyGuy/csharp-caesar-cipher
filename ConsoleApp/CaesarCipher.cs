using System;
using System.Text;

namespace ConsoleApp
{
    public class CaesarCipher
    {
        public char[] CustomAlphabet { get; }
        public string Message { private set; get; }
        public int Key { get; }
        
        public CaesarCipher(string message, int key)
        {
            Message = message;
            Key = key;
        }
        
        public CaesarCipher(string message, int key, char[] customAlphabet)
        {
            Message = message;
            Key = key;
            CustomAlphabet = customAlphabet;
        }

        public string Encrypt()
        {
            return Message = Encrypt(Message, Key, CustomAlphabet);
        }

        public string Decrypt()
        {
            return Message = Decrypt(Message, Key, CustomAlphabet);
        }

        public static string Encrypt(string message, int key, char[] alphabet = null)
        {
            var encryptedMessage = new StringBuilder();
            
            foreach (var character in message)
            {
                if (!char.IsLetter(character) && (alphabet == null || alphabet.Length == 0))
                {
                    encryptedMessage.Append(character);
                    continue;
                }

                if (alphabet == null || alphabet.Length == 0)
                {
                    var firstLetter = char.IsUpper(character) ? 'A' : 'a';
                    var lastLetter = char.IsUpper(character) ? 'Z' : 'z';
                    
                    var encryptedCharCode = (character + key - firstLetter) % 26 + firstLetter;
                    if (encryptedCharCode < firstLetter) encryptedCharCode = lastLetter - (firstLetter - encryptedCharCode - 1);

                    encryptedMessage.Append((char)encryptedCharCode);
                }
                else
                {
                    var charIndex = Array.IndexOf(alphabet, character);
                    if (charIndex == -1)
                    {
                        encryptedMessage.Append(character);
                        continue;
                    }

                    var encryptedCharIndex = (charIndex + key) % alphabet.Length;
                    if (encryptedCharIndex < 0) encryptedCharIndex = alphabet.Length + encryptedCharIndex;

                    var encryptedChar = alphabet[encryptedCharIndex];
                    encryptedMessage.Append(encryptedChar);
                }
            }
            
            return encryptedMessage.ToString();
        }

        public static string Decrypt(string message, int key, char[] alphabet = null)
        {
            return Encrypt(message, alphabet == null || alphabet.Length == 0 ? 26 - key : alphabet.Length - key, alphabet);
        }
    }
}