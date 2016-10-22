#region Linky na pouzite zdroje
//https://msdn.microsoft.com/en-us/library/system.security.cryptography.rfc2898derivebytes(v=vs.110).aspx
//http://stackoverflow.com/questions/20314089/overriding-inherited-class-constructor-but-still-calling-base-afterwards
#endregion

using System;
using System.Security.Cryptography;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace cryptography.CryptgraphyAlgorythms
{
    /// <summary>
    /// Zakladna trieda, z ktorej dedia vsetky ostatne krypto triedy
    /// </summary>
    public class BaseCryptographyClass
    {
        private Rfc2898DeriveBytes keyGenerator;
        private byte[] salt = 
        { 
            0x0, 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6,
            0xF1, 0xF0, 0xEE, 0x21, 0x22, 0x45 
        };
        private int iterationsCount = 100;
        private string password = "";

        protected byte[] IV;
        protected byte[] key;
        protected int blockSize = -1;

        public BaseCryptographyClass(string password, int keyLength)
        {
            this.password = password;
            GenerateKey(keyLength);
            tmp();
        }

        public BaseCryptographyClass(string password)
        {
            this.password = password;
        }

        /// <summary>
        /// Vygenerovanie pseudonahodneho kluca dlzky keyLength na zaklade hesla.
        /// </summary>
        /// <param name="keyLength">Dlzka kluca v bajtoch.</param>
        protected void GenerateKey(int keyLength)
        {
            keyGenerator = new Rfc2898DeriveBytes(password, salt, iterationsCount);
            key = keyGenerator.GetBytes(keyLength);
        }

        public void tmp()
        {
            foreach (var item in key)
            {
                System.Diagnostics.Debug.Write((char)item + "|");    
            }
            System.Diagnostics.Debug.WriteLine("");
        }
    }
}
