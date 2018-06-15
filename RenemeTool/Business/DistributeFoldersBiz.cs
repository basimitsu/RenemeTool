using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility.Converters;
using Utility.Log;

namespace RenemeTool.Business
{
    public class DistributeFoldersBiz
    {
        public static void SetFileDataSet(Action<int> action, FromDistribute from, DataTable dt, params string[] files)
        {
            switch (from)
            {
                case FromDistribute.FileName:
                    for (int i = 0; i < files.Length; i++)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(files[i]);
                        string afterFileName = string.Empty;

                        if (TryParthToDateTime(fileName, out afterFileName))
                        {
                            dt.Rows.Add(files[i], Path.Combine(Path.GetDirectoryName(files[i]), string.Concat(afterFileName, Path.GetExtension(files[i]))));
                        }
                        else
                        {
                            dt.Rows.Add(files[i]);
                        }

                        action.Invoke(i + 1);
                    }

                    break;
                case FromDistribute.CreateDate:
                    for (int i = 0; i < files.Length; i++)
                    {
                        string afterFileName = string.Empty;

                        if (TryParthFromCreateDate(files[i], out afterFileName))
                        {
                            dt.Rows.Add(files[i], Path.Combine(Path.GetDirectoryName(files[i]), string.Concat(afterFileName, Path.GetExtension(files[i]))));
                        }
                        else
                        {
                            dt.Rows.Add(files[i]);
                        }

                        action.Invoke(i + 1);
                    }

                    break;
                case FromDistribute.ShotDate:
                    for (int i = 0; i < files.Length; i++)
                    {
                        string afterFileName = string.Empty;

                        if (TryParthFromShotDate(files[i], out afterFileName))
                        {
                            dt.Rows.Add(files[i], Path.Combine(Path.GetDirectoryName(files[i]), string.Concat(afterFileName, Path.GetExtension(files[i]))));
                        }
                        else
                        {
                            dt.Rows.Add(files[i]);
                        }

                        action.Invoke(i + 1);
                    }

                    break;
            }
        }

        public static string ConvertToDateTime(string timespan)
        {
            string datetime = string.Empty;

            TryParthToDateTime(timespan, out datetime);

            return datetime;
        }

        public static bool TryParthToDateTime(string fileName, out string filePath)
        {
            bool result = false;
            filePath = null;

            // 日付らしき数列があれば日時に変換
            Match mtch = Regex.Match(fileName, @"(?<datemonth>20[0-9]{2}[01][0-9][0-3][0-9])");
            if (mtch.Success)
            {
                filePath = Path.Combine(mtch.Groups["datemonth"].Value.Substring(0, 6), fileName);
                result = true;
            }

            return result;
        }

        public static bool TryParthFromCreateDate(string sourceFilePath, out string filePath)
        {
            bool result = false;
            filePath = null;

            FileInfo fi = new FileInfo(sourceFilePath);

            // 日付らしき数列があれば日時に変換
            filePath = Path.Combine(fi.CreationTime.ToString("yyyyMM"), Path.GetFileNameWithoutExtension(sourceFilePath));
            result = true;

            return result;
        }

        public static bool TryParthFromShotDate(string sourceFilePath, out string filePath)
        {
            bool result = false;
            filePath = null;

            // 読み込む
            try
            {
                using (Bitmap bmp = new Bitmap(sourceFilePath))
                {
                    foreach (PropertyItem item in bmp.PropertyItems)
                    {
                        // Exif情報から撮影時間を取得する
                        if (item.Id == 0x9003 && item.Type == 2)
                        {
                            // 文字列に変換する
                            string val = Encoding.ASCII.GetString(item.Value);
                            val = val.Trim(new char[] { '\0' });
                            // DateTimeに変換
                            DateTime dt = DateTime.ParseExact(val, "yyyy:MM:dd HH:mm:ss", null);

                            filePath = Path.Combine(dt.ToString("yyyyMM"), Path.GetFileNameWithoutExtension(sourceFilePath));
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DebugOnFile.ExceptionWrite(ex);
            }

            return result;
        }
    }

    public enum FromDistribute
    {
        FileName,
        CreateDate,
        ShotDate,
    }

    // 拡張クラス
    public static class FromDistributeExt
    {
        // 拡張メソッド
        public static string Text(this FromDistribute value)
        {
            string[] values = { "ファイル名", "作成日時", "撮影日時" };
            return values[(int)value];
        }
    }

}
