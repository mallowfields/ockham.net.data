using System;

namespace Ockham.Data
{
    // Methods for detecting empty values, and converting to or from empty value types
    public partial class Converter
    {
        /// <summary>
        /// Test whether the input value is null or DBNull. Will also return true if the <see cref="Options"/> property of 
        /// this <see cref="Converter"/> instance includes the <see cref="ConvertOptions.EmptyStringAsNull"/> flag and <paramref name="value"/> is an empty string.
        /// </summary> 
        public bool IsNull(object value)
        {
            return Value.IsNull(value, this.Options);
        }

        /// <summary>
        /// Converts null or DBNull to null. Empty strings will also be converted to null if the <see cref="Options"/> property of the 
        /// current <see cref="Converter"/> instance includes the <see cref="ConvertOptions.EmptyStringAsNull"/> flag
        /// </summary>
        /// <param name="value">A value of any type</param> 
        public object ToNull(object value)
        {
            return (IsNull(value) ? null : value);
        }

        /// <summary>
        /// Converts null or DBNull to DBNull. Empty strings will also be converted to DBNull if the <see cref="Options"/> property of the 
        /// current <see cref="Converter"/> instance includes the <see cref="ConvertOptions.EmptyStringAsNull"/> flag
        /// </summary>
        /// <param name="value">A value of any type</param> 
        public object ToDBNull(object value)
        {
            return (IsNull(value) ? DBNull.Value : value);
        }

        /// <summary>
        /// Converts the default value of a type to DBNull
        /// </summary> 
        public object DefaultToDBNull<T>(T value) where T : struct => Convert.DefaultToDBNull(value);

        /// <summary>
        /// Converts the explicitly provided default value of a value type to DBNull
        /// </summary> 
        public object DefaultToDBNull<T>(T value, T defaultValue) where T : struct => Convert.DefaultToDBNull(value, defaultValue);

        /// <summary>
        /// Converts a null reference or default value of a nullable value type to DBNull
        /// </summary> 
        /// <remarks>This will return DBNull if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is false,
        /// or if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is true and <paramref name="value"/>.<see cref="Nullable{T}.Value"/> equals default(<typeparamref name="T"/>) </remarks>
        public object DefaultToDBNull<T>(T? value) where T : struct => Convert.DefaultToDBNull(value);

        /// <summary>
        /// Converts a null reference or default value of a nullable value type to DBNull
        /// </summary> 
        /// <remarks>This will return DBNull if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is false,
        /// or if <paramref name="value"/>.<see cref="Nullable{T}.HasValue"/> is true and <paramref name="value"/>.<see cref="Nullable{T}.Value"/> equals <paramref name="defaultValue"/></remarks>
        public object DefaultToDBNull<T>(T? value, T defaultValue) where T : struct => Convert.DefaultToDBNull(value, defaultValue);
    }
}