#region
//https://msdn.microsoft.com/en-us/library/system.security.cryptography.aes(v=vs.110).aspx
//http://csharphelper.com/blog/2014/09/encrypt-or-decrypt-files-in-c/
//http://stackoverflow.com/questions/25013380/how-to-remove-padding-in-decryption-in-c-sharp
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.IO;

using cryptography.Interfaces;

namespace cryptography.CryptgraphyAlgorythms
{
    public class AesCrypt : BaseCryptographyClass
    {
        private AesCryptoServiceProvider aesProvider;

        /// <summary>
        /// Konstruktor pre triedu pokryvajucu sifrovanie a desifrovanie suborov pomocou AES algoritmu.
        /// </summary>
        /// <param name="password">Heslo na zaklade ktoreho je vygenerovany kluc.</param>
        /// <param name="keyLength">Dlzka vygenerovanieho kluca.</param>
        public AesCrypt(string password, int keyLength)
            : base(password, keyLength)
        {
            EncryptFile("c:\\AATimo\\dsa.txt");
        }

        /// <summary>
        /// Konstruktor pre triedu pokryvajucu sifrovanie a desifrovanie suborov pomocou AES algoritmu.
        /// </summary>
        /// <param name="password">Heslo na zaklade ktoreho je vygenerovany kluc.</param>
        public AesCrypt(string password)
            : base(password)
        {

        }

        public void EncryptFile(string sourceFile)
        {
            InitializeAesProvider();

            FileInfo info = new FileInfo(sourceFile);
            string encryptedFile = info.FullName.Replace(info.Extension, ".enc");

            //long actualPosition = base.WriteFileHeader(sourceFile, encryptedFile);

            Stream inputStream = null;
            Stream outputStream = null;

            ICryptoTransform encryptor = aesProvider.CreateEncryptor();
            //alebo takto bez predosleho nastavovania key a IV
            //ICryptoTransform encryptor = aesProvider.CreateEncryptor(base.key,base.IV);
            try
            {
                inputStream = new FileStream(sourceFile, FileMode.Open);
                outputStream = new FileStream(encryptedFile + "tmp", FileMode.OpenOrCreate);
                //outputStream.Position = actualPosition;
                using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                {
                    const int bufferLength = 1024;
                    byte[] buffer = new byte[bufferLength];
                    int readedCount;
                    int countTmp = 0;
                    while (true)
                    {
                        readedCount = inputStream.Read(buffer, 0, bufferLength);
                        if (readedCount == 0) break;

                        // Write the bytes into the CryptoStream.
                        cryptoStream.Write(buffer, 0, readedCount);
                        if (countTmp % 500 == 0)
                            System.Diagnostics.Debug.WriteLine(countTmp);
                        countTmp++;
                    }
                    cryptoStream.FlushFinalBlock();
                    outputStream.Flush();
                    base.WriteEncryptedFile(outputStream, encryptedFile);
                    outputStream.Close();
                    File.Delete(encryptedFile + "tmp");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while trying to encrypt file! \n" + e.Message, "Vnimanie!",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
                inputStream.Close();
                //outputStream.Close();
            }

            encryptor.Dispose();
        }

        /// <summary>
        /// Metoda nacita HMAC a inicializacny vektor z hlavicky zasifrovaneho suboru, zvysok sa desifruje
        /// a zapise do noveho suboru s rovnakym nazvom ako zasifrovany subor a priponou .dec.
        /// </summary>
        /// <param name="encryptedFile">Cesta ku zasifrovanemu suboru.</param>
        public void DecryptFile(string encryptedFile)
        {
            InitializeAesProvider();
            byte[] originalHmac = base.ReadFileHeader(encryptedFile);

            FileInfo info = new FileInfo(encryptedFile);
            string decryptedFile = info.FullName.Replace(info.Extension, ".dec");

            Stream inputStream = new FileStream(encryptedFile, FileMode.Open);
            Stream outputStream = new FileStream(decryptedFile, FileMode.OpenOrCreate);
            inputStream.Position = originalHmac.Length + base.IV.Length;
            byte[] newHmac = base.GenerateHMAC(inputStream);
            inputStream.Position = originalHmac.Length + base.IV.Length;
            Exception e = new Exception("Data integrity was endangered or entered password is incorrect!");

            aesProvider.IV = base.IV;
            ICryptoTransform encryptor = aesProvider.CreateDecryptor();
            try
            {
                if (!base.CompareHmacs(originalHmac, newHmac))
                    throw e;
                using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                {
                    const int bufferLength = 1024;

                    long blocksCount = (inputStream.Length - originalHmac.Length + base.IV.Length) / 1024;
                    for (long i = 0; i < blocksCount; i++)
                    {
                        byte[] buffer = new byte[bufferLength];
                        inputStream.Read(buffer, 0, bufferLength);
                        cryptoStream.Write(buffer, 0, buffer.Length);
                    }
                    byte[] lastBuffer = new byte[inputStream.Length - originalHmac.Length - base.IV.Length - blocksCount * 1024];
                    inputStream.Read(lastBuffer, 0, lastBuffer.Length);
                    cryptoStream.Write(lastBuffer, 0, lastBuffer.Length);

                    cryptoStream.FlushFinalBlock();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while trying to decrypt file! \n" + ex.Message, "Vnimanie!",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            encryptor.Dispose();
        }

        private void InitializeAesProvider()
        {
            aesProvider = new AesCryptoServiceProvider();
            base.GenerateKey(GetKeyLength() / 8);
            aesProvider.GenerateIV();

            aesProvider.Key = base.key;
            base.IV = aesProvider.IV;
            base.blockSize = aesProvider.BlockSize * 8;
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.Zeros;
        }

        /// <summary>
        /// Metoda vracia podporovanu dlzku kluca AesCryptoServiceProviderom
        /// </summary>
        /// <returns>Dlzka kluca v bitoch.</returns>
        private int GetKeyLength()
        {
            int result = 0;
            for (int i = 1024; i > 1; i--)
                if (aesProvider.ValidKeySize(i))
                {
                    result = i;
                    break;
                }

            return result;
        }

        public static byte[] TrimEnd(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);

            Array.Resize(ref array, lastIndex + 1);

            return array;
        }
    }
}