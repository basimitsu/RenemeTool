using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Utility.Converters
{
    /// <summary>
    /// カラーコンバータ
    /// </summary>
    public class BrushConverterFor16 : IValueConverter
    {
        /// <summary>
        /// カラーコンバータのインスタンス化
        /// </summary>
        private ColorConverter _cC = new ColorConverter();

        /// <summary>
        /// 16進数をColor型に変換する
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ情報</param>
        /// <returns>カラー</returns>
        public object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            if (value != null)
            {
                // Colorに変換
                return this._cC.ConvertFrom(value);
            }

            return value;
        }

        /// <summary>
        /// Color型を16進数に変換する
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ情報</param>
        /// <returns>16進数</returns>
        public object ConvertBack(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            ////TODO:
            System.Type test = null;
            return this._cC.ConvertTo(value, test);
        }
    }
}
