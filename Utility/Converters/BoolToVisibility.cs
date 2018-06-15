using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Utility.Converters
{
    /// <summary>
    /// ブール型コンバータ
    /// </summary>
    public class BoolToVisibility : IValueConverter
    {
        /// <summary>
        /// Bool型をVisibility型に変換する
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ情報</param>
        /// <returns>表示非表示</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                // trueの場合Visiblenを代入
                value = (bool)value ? Visibility.Visible : Visibility.Hidden;
            }

            return value;
        }

        /// <summary>
        /// Visibility型をBool型に変換する
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="targetType">型</param>
        /// <param name="parameter">パラメータ</param>
        /// <param name="culture">カルチャ情報</param>
        /// <returns>Bool値</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Visibleの場合true
            return (Visibility)value == Visibility.Visible;
        }
    }
}
