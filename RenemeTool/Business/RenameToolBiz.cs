using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility.Converters;

namespace RenemeTool.Business
{
    public class RenameToolBiz
    {
        public static void SetFileDataSet(Action<int> action ,DataTable dt, params string[] files )
        {
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
        }

        public static string ConvertToDateTime(string timespan)
        {
            string datetime = string.Empty;

            TryParthToDateTime(timespan, out datetime);

            return datetime;
        }

        public static bool TryParthToDateTime(string timespan, out string datetime)
        {
            bool result = false;
            datetime = null;

            // タイムスパンらしき数列があれば日時に変換
            double timestamp;
            Match mtch = Regex.Match(timespan, @"(?<timespan>[0-9]{13})");
            if (mtch.Success)
            {
                if (double.TryParse(mtch.Groups["timespan"].Value.Insert(10, "."), out timestamp))
                {
                    datetime = Regex.Replace(timespan, @"(?<timespan>[0-9]{13})", Date.ToDateTime(timestamp).ToString("yyyyMMdd_HHmmss_fff"));
                    result = true;
                }
            }
            else
            {
                mtch = Regex.Match(timespan, @"(?<timespan>[0-9]{10})");
                if (mtch.Success)
                {
                    if (double.TryParse(mtch.Groups["timespan"].Value, out timestamp))
                    {
                        datetime = Regex.Replace(timespan, @"(?<timespan>[0-9]{10})", Date.ToDateTime(timestamp).ToString("yyyyMMdd_HHmmss"));
                    result = true;
                    }
                    else
                    {
                        datetime = timespan;
                    }
                }
            }

            return result;
        }
    }
}
