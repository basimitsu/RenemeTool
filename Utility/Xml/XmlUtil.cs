using System;
using Utility.Log;

namespace Utility.Xml
{
    /// <summary>
    /// XMLユーティリティ
    /// </summary>
    public static class XmlUtil
    {
        /// <summary>
        /// オブジェクトの内容をXMLファイルに保存（シリアル化）する
        /// </summary>
        /// <param name="fileName">保存先</param>
        /// <param name="value">保存対象データ</param>
        public static void Serialize(string fileName, object value)
        {
            // XmlSerializerオブジェクトを作成
            // オブジェクトの型を指定する
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(value.GetType());

            // 書き込むファイルを開く（UTF-8 BOM無し）
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, new System.Text.UTF8Encoding(false));

            // シリアル化し、XMLファイルに保存する
            serializer.Serialize(sw, value);

            // ファイルを閉じる
            sw.Close();
        }

        /// <summary>
        /// XMLファイルの内容をオブジェクトに復元（逆シリアル化）する
        /// </summary>
        /// <typeparam name="T">型</typeparam>
        /// <param name="fileName">保存元</param>
        /// <returns>指定した型に格納したデータ</returns>
        public static T SerializeBack<T>(string fileName)
        {
            // 宣言
            T value;

            // 読み込むファイルを開く
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false));

            try
            {
                // XmlSerializerオブジェクトを作成
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));

                // XMLファイルから読み込み、逆シリアル化する
                value = (T)serializer.Deserialize(sr);
            }
            catch (Exception e)
            {
                DebugOnFile.ExceptionWrite(e);
                throw;
            }
            finally
            {
                // ファイルを閉じる
                sr.Close();
            }

            return value;
        }
    }
}
