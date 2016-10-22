#region
//https://msdn.microsoft.com/en-us/library/system.security.cryptography.aes(v=vs.110).aspx
//http://csharphelper.com/blog/2014/09/encrypt-or-decrypt-files-in-c/
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
        public AesCrypt(string password, int keyLength) : base(password, keyLength)
        {
            EncryptFile("c:\\AATimo\\dsa.txt");
        }

        /// <summary>
        /// Konstruktor pre triedu pokryvajucu sifrovanie a desifrovanie suborov pomocou AES algoritmu.
        /// </summary>
        /// <param name="password">Heslo na zaklade ktoreho je vygenerovany kluc.</param>
        public AesCrypt(string password) : base(password)
        {

        }

        public void EncryptFile(string sourceFile)
        {
            InitializeAesProvider();

            FileInfo info = new FileInfo(sourceFile);
            string encryptedFile = info.FullName.Replace(info.Extension,".enc");

            long actualPosition = base.WriteFileHeader(sourceFile, encryptedFile);
            
            Stream inputStream = new FileStream(sourceFile, FileMode.Open);
            Stream outputStream = new FileStream(encryptedFile, FileMode.OpenOrCreate);
            outputStream.Position = actualPosition;

            ICryptoTransform encryptor = aesProvider.CreateEncryptor();
            //alebo takto bez predosleho nastavovania key a IV
            //ICryptoTransform encryptor = aesProvider.CreateEncryptor(base.key,base.IV);
            try
            {
                using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                {
                    const int bufferLength = 1024;
                    byte[] buffer = new byte[bufferLength];
                    int readedCount;
                    while (true)
                    {
                        readedCount = inputStream.Read(buffer, 0, bufferLength);
                        if (readedCount == 0) break;

                        // Write the bytes into the CryptoStream.
                        cryptoStream.Write(buffer, 0, readedCount);
                    }
                }
            }
            catch(Exception e)
            {
                inputStream.Close();
                outputStream.Close();
                System.Windows.Forms.MessageBox.Show("An error occured while trying to encrypt file! \n" + e.Message,"Vnimanie!",
                    System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
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
            byte[] hmac = base.ReadFileHeader(encryptedFile);

            FileInfo info = new FileInfo(encryptedFile);
            string decryptedFile = info.FullName.Replace(info.Extension, ".dec");

            Stream inputStream = new FileStream(encryptedFile, FileMode.Open);
            Stream outputStream = new FileStream(decryptedFile, FileMode.OpenOrCreate);
            inputStream.Position = hmac.Length + base.IV.Length;

            aesProvider.IV = base.IV;
            ICryptoTransform encryptor = aesProvider.CreateDecryptor();
            try
            {
                using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                {
                    const int bufferLength = 1024;
                    byte[] buffer = new byte[bufferLength];
                    int readedCount;
                    while (true)
                    {
                        readedCount = inputStream.Read(buffer, 0, bufferLength);
                        if (readedCount == 0) break;

                        // Write the bytes into the CryptoStream.
                        cryptoStream.Write(buffer, 0, readedCount);
                    }
                }
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show("An error occured while trying to decrypt file! \n" + e.Message, "Vnimanie!",
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
    }
}
