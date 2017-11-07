using System;

namespace Ockham.Data
{
    /// <summary>
    /// Flexible data conversion methods for converting between simple types
    /// </summary>
    public partial class Converter
    {
        public static Converter Strict { get; } = new Converter(ConvertOptions.Strict);
        public static Converter Default { get; } = new Converter(ConvertOptions.Default);
        public static Converter Relaxed { get; } = new Converter(ConvertOptions.Relaxed);

        public Converter(ConvertOptions options) { Options = options; }

        public ConvertOptions Options { get; }

        public object Force(object value, Type targetType) => throw null;
        public T Force<T>(object value) => throw null;
        public T Force<T>(object value, T defaultValue) => throw null;
        public T To<T>(object value) => throw null;
        public object To(object value, Type targetType) => throw null;

        public bool IsNull(object value) => throw null;
        public object ToNull(object value) => throw null;
        public object ToDBNull(object value) => throw null;
        public object DefaultToDBNull<T>(T value) where T : struct => throw null;
        public object DefaultToDBNull<T>(T value, T defaultValue) where T : struct => throw null;
        public object DefaultToDBNull<T>(T? value) where T : struct => throw null;
        public object DefaultToDBNull<T>(T? value, T defaultValue) where T : struct => throw null;
    }

    public partial class Converter
    {
        // ------------------------------------------------------------------
        // ** HEY, YOU, DEVELOPER! **
        // 
        //  Do not modify this section directly!
        //  
        //  Update and rerun the code generating script Generate_Convert_Aliases_CSharp.ps1 with $instance = $true and $reference = $true
        // ------------------------------------------------------------------ 

        public bool ToBool(object value) => throw null;
        public DateTime ToDate(object value) => throw null;
        public decimal ToDec(object value) => throw null;
        public double ToDbl(object value) => throw null;
        public Guid ToGuid(object value) => throw null;
        public int ToInt(object value) => throw null;
        public long ToLng(object value) => throw null;
        public string ToStr(object value) => throw null;
        public TimeSpan ToTimeSpan(object value) => throw null;
    }
}
