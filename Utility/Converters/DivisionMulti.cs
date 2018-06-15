using System;
using System.Globalization;
using System.Windows.Data;

namespace Utility.Converters
{
    /// <summary>
    /// 値コンバータ
    /// </summary>
    public class DivisionMulti : IValueConverter
    {
        /// <summary>
        /// 値をフォントサイズ用に小さくする
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ情報</param>
        /// <returns>小さくした値</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int div;
            if (value != null && parameter != null && int.TryParse(parameter.ToString(), out div))
            {
                // 親windowsの高さをもとに計算
                value = (double)value / div;
            }

            return value;
        }

        /// <summary>
        /// 値をフォントサイズ用に小さくする
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ情報</param>
        /// <returns>大きくした値</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int div;
            if (parameter != null && int.TryParse(parameter.ToString(), out div))
            {
                // Convertの逆算
                return ((double)value) * div;
            }

            return value;
        }
    }
}
