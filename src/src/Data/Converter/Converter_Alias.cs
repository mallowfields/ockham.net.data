using System;

namespace Ockham.Data
{
    // ------------------------------------------------------------------
    // ** HEY, YOU, DEVELOPER! **
    // 
    //  Do not modify this file directly!
    //  
    //  Update and rerun the code generating script Generate_Convert_Aliases_CSharp.ps1 with $instance = $true
    // ------------------------------------------------------------------

    // Type-specific conversion wrappers for underlying To method
    public partial class Converter
    {
        /// <summary>
        /// Convert any input value to an equivalent boolean value. Attempting to convert
        /// a value that has no meaningful boolean equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public bool ToBool(object value)
        {
            return To<bool>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent date time value. Attempting to convert
        /// a value that has no meaningful date or time equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public DateTime ToDate(object value)
        {
            return To<DateTime>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent exact decimal value. Attempting to convert
        /// a value that has no meaningful decimal equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public decimal ToDec(object value)
        {
            return To<decimal>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent double-precision floating point number value. Attempting to convert
        /// a value that has no meaningful floating point equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public double ToDbl(object value)
        {
            return To<double>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 128-bit globally unique identifier value. Attempting to convert
        /// a value that has no meaningful GUID equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public Guid ToGuid(object value)
        {
            return To<Guid>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 32-bit signed integer value. Attempting to convert
        /// a value that has no meaningful integer equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public int ToInt(object value)
        {
            return To<int>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent 64-bit signed integer value. Attempting to convert
        /// a value that has no meaningful integer equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public long ToLng(object value)
        {
            return To<long>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent string value. Attempting to convert
        /// a value that has no meaningful string equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public string ToStr(object value)
        {
            return To<string>(value);
        }

        /// <summary>
        /// Convert any input value to an equivalent timespan value. Attempting to convert
        /// a value that has no meaningful timespan equivalent, including an empty value,
        /// will cause an <see cref="System.InvalidCastException" /> to be raised.
        /// </summary>
        /// <param name="value">Any value</param>
        /// <seealso cref="Ockham.Data.Converter.To{T}(Object)"/>
        public TimeSpan ToTimeSpan(object value)
        {
            return To<TimeSpan>(value);
        }
    }
}
