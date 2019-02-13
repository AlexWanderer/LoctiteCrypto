using System;
using System.Security.Cryptography;
using System.Text;

namespace HackForums.gigajew
{
    /// <summary>
    /// A safe, reliable RSA/AES combined encryption/decryption class by gigajew @ www.hackforums.net
    /// </summary>
    public class LoctiteCrypto : IDisposable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoctiteCrypto(int asymmetric_key_size = 2048, bool big_endian = true, bool byte_order_mark = false)
        {
            _aes = new AesCryptoServiceProvider();
            _aes.KeySize = 256;
            _aes.BlockSize = 128;
            _rsa = new RSACryptoServiceProvider(asymmetric_key_size);
            _unicode = new UnicodeEncoding(big_endian, byte_order_mark);
        }

        /// <summary>
        /// Generate a public key for encryption
        /// </summary>
        public string GeneratePublicKey()
        {
            return _rsa.ToXmlString(false);
        }

        /// <summary>
        /// Generate a private key for decryption
        /// </summary>
        public string GeneratePrivateKey()
        {
            return _rsa.ToXmlString(true);
        }

        /// <summary>
        /// Decrypt a string
        /// </summary>
        public string DecryptString(EncryptedBlob blob, string private_asymmetric_key)
        {
            return _unicode.GetString(DecryptData(blob, private_asymmetric_key));
        }

        /// <summary>
        /// Decrypt binary data
        /// </summary>
        public byte[] DecryptData(EncryptedBlob blob, string private_asymmetric_key)
        {
            _rsa.FromXmlString(private_asymmetric_key);
            _aes.Key = _rsa.Decrypt(blob.EncryptedSymmetricKey, true);
            _aes.IV = _rsa.Decrypt(blob.EncryptedSymmetricIV, true);
            using (ICryptoTransform decryptor = _aes.CreateDecryptor())
            {
                return decryptor.TransformFinalBlock(blob.EncryptedData, 0, blob.EncryptedData.Length);
            }
        }

        /// <summary>
        /// Encrypt a string
        /// </summary>
        public EncryptedBlob EncryptString(string raw_message, string public_asymmetric_key)
        {
            return EncryptData(_unicode.GetBytes(raw_message), public_asymmetric_key);
        }

        /// <summary>
        /// Encrypt binary data
        /// </summary>
        public EncryptedBlob EncryptData(byte[] raw_binary_data, string public_asymmetric_key)
        {
            _aes.GenerateKey();
            _aes.GenerateIV();
            byte[] encrypted_data;
            using (ICryptoTransform encryptor = _aes.CreateEncryptor())
            {
                encrypted_data = encryptor.TransformFinalBlock(raw_binary_data, 0, raw_binary_data.Length);
            }
            EncryptedBlob blob = new EncryptedBlob();
            blob.EncryptedData = encrypted_data;
            _rsa.FromXmlString(public_asymmetric_key);
            blob.EncryptedSymmetricKey = _rsa.Encrypt(_aes.Key, true);
            blob.EncryptedSymmetricIV = _rsa.Encrypt(_aes.IV, true);
            return blob;
        }

        /// <summary>
        /// Frees resources
        /// </summary>
        public void Dispose()
        {
            _aes.Dispose();
            _rsa.Dispose();
            _unicode = null;
        }

        private AesCryptoServiceProvider _aes;
        private RSACryptoServiceProvider _rsa;
        private UnicodeEncoding _unicode;
    }

    /// <summary>
    /// A blob of encrypted data
    /// </summary>
    public class EncryptedBlob
    {
        public byte[] EncryptedSymmetricKey
        {
            get; set;
        }

        public byte[] EncryptedSymmetricIV
        {
            get; set;
        }

        public byte[] EncryptedData
        {
            get; set;
        }
    }
}
