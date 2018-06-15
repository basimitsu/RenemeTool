using System;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Encryption
{
    public class AES
    {
        // 128bit(16byte)のIV（初期ベクタ）とKey（暗号キー）
        // private const string AesIV = @"!QAZ2WSX#EDC4RFV";
        // private const string AesKey = @"5TGB&YHN7UJM(IK<";

        /// <summary>
        /// 128bit(16byte)のIV（初期ベクタ）とKey（暗号キー）
        /// </summary>
        private const string AesIV = @"!ISHIBASHI_MITSU";
        private const string AesKey = @"?ISHIBASHI_MITSU";

        /// <summary>
        /// 文字列をAESで暗号化
        /// </summary>
        public static string Encrypt(string text)
        {
            // AES暗号化サービスプロバイダ
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.IV = Encoding.UTF8.GetBytes(AesIV);
                aes.Key = Encoding.UTF8.GetBytes(AesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // 文字列をバイト型配列に変換
                byte[] src = Encoding.Unicode.GetBytes(text);

                // 暗号化する
                using (ICryptoTransform encrypt = aes.CreateEncryptor())
                {
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                    // バイト型配列からBase64形式の文字列に変換
                    return Convert.ToBase64String(dest);
                }
            }
        }

        /// <summary>
        /// 文字列をAESで復号化
        /// </summary>
        public static string Decrypt(string text)
        {
            // AES暗号化サービスプロバイダ
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.IV = Encoding.UTF8.GetBytes(AesIV);
                aes.Key = Encoding.UTF8.GetBytes(AesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Base64形式の文字列からバイト型配列に変換
                byte[] src = Convert.FromBase64String(text);

                // 複号化する
                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    return Encoding.Unicode.GetString(dest);
                }
            }
        }
    }
}
