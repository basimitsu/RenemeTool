using System.Runtime.InteropServices;
using System.Text;

namespace Utility.Ini
{
    public class IniUtil
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedstring,
            int nSize,
            string lpFileName);

        /// <summary>
        /// iniファイルから設定値を取得する
        /// </summary>
        /// <param name="path">ファイルパス</param>
        /// <param name="section">セクション</param>
        /// <param name="key">キー</param>
        /// <returns></returns>
        public static string GetIniValue(string path, string section, string key)
        {
            StringBuilder sb = new StringBuilder(256);
            GetPrivateProfileString(section, key, string.Empty, sb, sb.Capacity, path);
            return sb.ToString();
        }
    }
}
