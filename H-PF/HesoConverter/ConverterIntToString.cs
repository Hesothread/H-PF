using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace H_PF.HesoConverter
{
    class ConverterIntToString : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return (int?)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            if (int.TryParse(value as string, out int result))
                return result;
            else
                return null;
        }

        #endregion
    }
}
