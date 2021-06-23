using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaeserCipherTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string message = "ABC";
            const int key = 2;
            const string expected = "CDE";
            
            var encryptedMessage = CaesarCipher.Encrypt(message, key);
            
            Assert.AreEqual(expected, encryptedMessage);
        }
        
        [TestMethod]
        public void TestMethod2()
        {
            const string message = "ABC";
            const int key = -3;
            const string expected = "XYZ";
            
            var encryptedMessage = CaesarCipher.Encrypt(message, key);

            Assert.AreEqual(expected, encryptedMessage);
        }
        
        [TestMethod]
        public void TestMethod3()
        {
            const string message = "Qtwjr nuxzr";
            const int key = 5;
            const string expected = "Lorem ipsum";

            var cipher = new CaesarCipher(message, key);
            cipher.Decrypt();

            Assert.AreEqual(expected, cipher.Message);
        }
        
        [TestMethod]
        public void TestMethod4()
        {
            const string message = "Czggj rjmgy 55 ___ 55";
            const int key = -5;
            const string expected = "Hello world 55 ___ 55";

            var cipher = new CaesarCipher(message, key);
            cipher.Decrypt();

            Assert.AreEqual(expected, cipher.Message);
        }
    }
}