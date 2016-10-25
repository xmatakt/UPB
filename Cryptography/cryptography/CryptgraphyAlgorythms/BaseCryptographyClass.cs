#region Linky na pouzite zdroje
//https://msdn.microsoft.com/en-us/library/system.security.cryptography.rfc2898derivebytes(v=vs.110).aspx
//http://stackoverflow.com/questions/20314089/overriding-inherited-class-constructor-but-still-calling-base-afterwards
#endregion

using System;
using System.Security.Cryptography;
using System.IO;

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
        private string password = "heslo";
        private const int magicConstant = 1024 * 10;

        protected byte[] IV;
        protected byte[] key;
        protected int blockSize = -1;

        public BaseCryptographyClass(string password, int keyLength)
        {
            this.password = password;
            GenerateKey(keyLength);
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

        /// <summary>
        /// Zapise HMAC a IV na zaciatok zasifrovaneho suboru, a samotny zasifrovany subor.
        /// </summary>
        /// <param name="cyphertext">Stream so cyphertextom.</param>
        /// <param name="destinationFile">Cesta ku zasifrovanemu suboru.</param>
        protected void WriteEncryptedFile(Stream cyphertext, string destinationFile)
        {
            HMACSHA256 hmac = new HMACSHA256(key);
            byte[] hash;

            cyphertext.Position = 0;
            if (cyphertext.Length > magicConstant)
            {
                byte[] arr = new byte[magicConstant];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = Convert.ToByte(cyphertext.ReadByte());
                hash = hmac.ComputeHash(arr, 0, magicConstant);
            }
            else
                hash = hmac.ComputeHash(cyphertext);

            try
            {
                cyphertext.Position = 0;
                using (FileStream outputStream = new FileStream(destinationFile, FileMode.OpenOrCreate))
                {
                    outputStream.Write(hash, 0, hash.Length);
                    outputStream.Write(IV, 0, IV.Length);
                    cyphertext.Position = 0;
                    long length = cyphertext.Length;
                    cyphertext.CopyTo(outputStream);
                    
                    outputStream.Flush();
                    outputStream.Close();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while writting encrypted file header!\n" + e.Message,
                    "Vnimanie", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metoda precita zo zasifrovaneho suboru HMAC (nezasifrovaneho suboru) a inicializacny vektor.
        /// Inicializacni vektor sa priradi do pola IV, HMAC je navratovou hodnotou.
        /// </summary>
        /// <param name="encryptedFile">Cesta ku zasifrovanemu suboru.</param>
        /// <returns>Vrati pole bajtov, v ktorom je ulozeny HMAC nezasifrovaneho suboru, alebo null ak sa pri nacitani vyskytne chyba.</returns>
        protected byte[] ReadFileHeader(string encryptedFile)
        {
            byte[] result = new byte[32];

            try
            {
                using (FileStream inputStream = new FileStream(encryptedFile, FileMode.Open))
                {
                    //viem ze prvych 32 bajtov je HMAC nezasifrovaneho suboru
                    inputStream.Read(result, 0, 32);
                    //dalsich x bajtov je inicializacny vektor
                    inputStream.Read(IV, 0, IV.Length);

                    inputStream.Flush();
                    inputStream.Close();
                    return result;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while reading encrypted file header!\n" + e.Message,
                    "Vnimanie", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Metoda vygeneruje hash pre decryptovany subor.
        /// </summary>
        /// <param name="cyphertextStream">Stream so cyphertextom.</param>
        /// <returns></returns>
        protected byte[] GenerateHMAC(Stream cyphertextStream)
        {
            HMACSHA256 hmac = new HMACSHA256(key);
            try
            {
                if (cyphertextStream.Length > magicConstant)
                {
                    byte[] arr = new byte[magicConstant];
                    for (int i = 0; i < arr.Length; i++)
                        arr[i] = Convert.ToByte(cyphertextStream.ReadByte());
                     return hmac.ComputeHash(arr, 0, magicConstant);
                }
                else
                    return hmac.ComputeHash(cyphertextStream);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while trying to get HMAC for decrypted file!\n" + e.Message,
                    "Vnimanie", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }

        protected bool CompareHmacs(byte[] hmac1, byte[] hmac2)
        {
            for (int i = 0; i < hmac1.Length; i++)
                if (hmac1[i] != hmac2[i])
                    return false;

            return true;
        }
    }
}