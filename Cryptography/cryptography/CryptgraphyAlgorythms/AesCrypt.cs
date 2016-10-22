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

        public void EncryptFile(string path)
        {
            InitializeAesProvider();   

            FileInfo info = new FileInfo(path);
            
            System.Diagnostics.Debug.WriteLine(info.Name); //toto
            System.Diagnostics.Debug.WriteLine(info.Name.Replace(info.Extension,".enc"));


            Stream inputStream = new FileStream(path, FileMode.Open);
            //Stream outputStrem = new FileStream( ,FileMode.OpenOrCreate)

            ICryptoTransform encryptor = aesProvider.CreateEncryptor();
            //alebo takto bez predosleho nastavovania key a IV
            //ICryptoTransform encryptor = aesProvider.CreateEncryptor(base.key,base.IV);

            //try
            //{
            //    using (CryptoStream cryptoStream =
            //        new CryptoStream(, encryptor,
            //            CryptoStreamMode.Write))
            //    {
            //        const int block_size = 1024;
            //        byte[] buffer = new byte[block_size];
            //        int bytes_read;
            //        while (true)
            //        {
            //            // Read some bytes.
            //            bytes_read = in_stream.Read(buffer, 0, block_size);
            //            if (bytes_read == 0) break;

            //            // Write the bytes into the CryptoStream.
            //            cryptoStream.Write(buffer, 0, bytes_read);
            //        }
            //    } // using crypto_stream 
            //}
            //catch
            //{
            //}
        }

        private void InitializeAesProvider()
        {
            aesProvider = new AesCryptoServiceProvider();
            base.GenerateKey(GetKeyLength() / 8);
            aesProvider.GenerateIV();

            aesProvider.Key = base.key;
            base.IV = aesProvider.IV;
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.Zeros;

            System.Windows.Forms.MessageBox.Show(aesProvider.BlockSize.ToString());
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
