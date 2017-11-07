using System;

namespace Ockham.Reflection
{
    /// <summary>
    /// Static utility methods for inspecting types 
    /// </summary>
    public static class TypeUtil
    {
        public static bool IsStaticClass(Type type) => throw null; 
        public static bool IsIntegerType(Type type) => throw null;
        public static bool IsNumberType(Type type) => throw null; 
        public static bool IsNullableOfT(Type type) => throw null;
        public static bool IsNullableOfT(Type type, ref Type elementType) => throw null;
        public static bool IsEnumerable(Type type, ref Type elementType) => throw null;
        public static bool IsEnumerable(Type type, bool excludeString, ref Type elementType) => throw null;
        public static bool Implements(Type type, Type interfaceType) => throw null;
        public static bool Implements(Type type, Type interfaceType, ref Type[] typeArguments) => throw null;
        public static bool IsConstructedType(Type type, Type genericTypeDefinition) => throw null;
        public static bool IsConstructedType(Type type, Type genericTypeDefinition, ref Type[] typeArguments) => throw null;
        public static object Default(Type type) => throw null; 
    }
}
