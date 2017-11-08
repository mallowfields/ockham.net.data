namespace Ockham.Data
{
    public static class Convert
    {
        public static object DefaultToDBNull<T>(T value) where T : struct;
        public static object DefaultToDBNull<T>(T value, T defaultValue) where T : struct;
        public static object DefaultToDBNull<T>(Nullable<T> value) where T : struct;
        public static object DefaultToDBNull<T>(Nullable<T> value, T defaultValue) where T : struct;
        public static object Force(object value, Type targetType);
        public static T Force<T>(object value);
        public static T Force<T>(object value, T defaultValue);
        public static bool ForceBool(object value);
        public static bool ForceBool(object value, bool defaultValue);
        public static DateTime ForceDate(object value);
        public static DateTime ForceDate(object value, DateTime defaultValue);
        public static double ForceDbl(object value);
        public static double ForceDbl(object value, double defaultValue);
        public static decimal ForceDec(object value);
        public static decimal ForceDec(object value, decimal defaultValue);
        public static Guid ForceGuid(object value);
        public static Guid ForceGuid(object value, Guid defaultValue);
        public static int ForceInt(object value);
        public static int ForceInt(object value, int defaultValue);
        public static long ForceLng(object value);
        public static long ForceLng(object value, long defaultValue);
        public static string ForceStr(object value);
        public static string ForceStr(object value, string defaultValue);
        public static TimeSpan ForceTimeSpan(object value);
        public static TimeSpan ForceTimeSpan(object value, TimeSpan defaultValue);
        public static object To(object value, Type targetType);
        public static object To(object value, Type targetType, ConvertOptions options);
        public static T To<T>(object value);
        public static T To<T>(object value, ConvertOptions options);
        public static bool ToBool(object value);
        public static DateTime ToDate(object value);
        public static double ToDbl(object value);
        public static object ToDBNull(object value, bool emptyStringAsNull=true);
        public static decimal ToDec(object value);
        public static Guid ToGuid(object value);
        public static int ToInt(object value);
        public static long ToLng(object value);
        public static object ToNull(object value, bool emptyStringAsNull=true);
        public static string ToStr(object value);
        public static TimeSpan ToTimeSpan(object value);
    }
    public class Converter
    {
        public Converter(ConvertOptions options);
        public static Converter Default { get; }
        public ConvertOptions Options { get; }
        public static Converter Relaxed { get; }
        public static Converter Strict { get; }
        public object DefaultToDBNull<T>(T value) where T : struct;
        public object DefaultToDBNull<T>(T value, T defaultValue) where T : struct;
        public object DefaultToDBNull<T>(Nullable<T> value) where T : struct;
        public object DefaultToDBNull<T>(Nullable<T> value, T defaultValue) where T : struct;
        public object Force(object value, Type targetType);
        public T Force<T>(object value);
        public T Force<T>(object value, T defaultValue);
        public bool IsNull(object value);
        public object To(object value, Type targetType);
        public T To<T>(object value);
        public bool ToBool(object value);
        public DateTime ToDate(object value);
        public double ToDbl(object value);
        public object ToDBNull(object value);
        public decimal ToDec(object value);
        public Guid ToGuid(object value);
        public int ToInt(object value);
        public long ToLng(object value);
        public object ToNull(object value);
        public string ToStr(object value);
        public TimeSpan ToTimeSpan(object value);
    }
    public enum ConvertOptions
    {
        Allow0xHex = 8,
        AllowHex = 12,
        AllowVBHex = 4,
        Default = 1,
        EmptyStringAsNull = 1,
        None = 0,
        NullToValueDefault = 2,
        Relaxed = 3,
        Strict = 0,
    }
    public static class Value
    {
        public static bool IsDefault(object value);
        public static bool IsNull(object value);
        public static bool IsNull(object value, ConvertOptions options);
        public static bool IsNull(object value, bool emptyStringAsNull);
        public static bool IsNullOrEmpty(object value);
        public static bool IsNullOrWhitespace(object value);
        public static bool IsNumeric(object value);
        public static bool IsNumeric(object value, ConvertOptions options);
    }
}
namespace Ockham.Reflection
{
    public static class TypeUtil
    {
        public static object Default(Type type);
        public static bool Implements(Type type, Type interfaceType);
        public static bool Implements(Type type, Type interfaceType, ref Type[] typeArguments);
        public static bool IsConstructedType(Type type, Type genericTypeDefinition);
        public static bool IsConstructedType(Type type, Type genericTypeDefinition, ref Type[] typeArguments);
        public static bool IsEnumerable(Type type, bool excludeString, ref Type elementType);
        public static bool IsEnumerable(Type type, ref Type elementType);
        public static bool IsIntegerType(Type type);
        public static bool IsNullableOfT(Type type);
        public static bool IsNullableOfT(Type type, ref Type elementType);
        public static bool IsNumberType(Type type);
        public static bool IsStaticClass(Type type);
    }
}
