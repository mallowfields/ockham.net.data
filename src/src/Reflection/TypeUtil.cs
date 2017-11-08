using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ockham.Reflection
{
    /// <summary>
    /// Static utility methods for inspecting types 
    /// </summary>
    public static class TypeUtil
    {
        /// <summary>
        /// Determine if a type is a static class (Module in VB.Net)
        /// </summary> 
        public static bool IsStaticClass(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsClass && typeInfo.IsAbstract && typeInfo.IsSealed;
        }

        /// <summary>
        /// Determine if the specified type is an integer type. Returns true for enums.
        /// </summary> 
        public static bool IsIntegerType(Type type)
        {
            return _IsNumberType(type, true);
        }

        /// <summary>
        /// Determine if the specified type is a numeric (integer, float, or decimal) type. Returns true for enums.
        /// </summary> 
        public static bool IsNumberType(Type type)
        {
            return _IsNumberType(type, false);
        }

        private static bool _IsNumberType(Type type, bool integersOnly)
        {

            if (type.GetTypeInfo().IsEnum) return true;

            switch (System.Convert.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return !integersOnly;
            }

            return false;
        }


        /// <summary>
        /// Determine if the specified type inherits from <see cref="System.Nullable{T}"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsNullableOfT(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsGenericType && !typeInfo.IsGenericTypeDefinition && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Determine if the specified type inherits from <see cref="System.Nullable{T}"/>, and return the inner type if it is 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementType"></param>
        /// <returns></returns>
        public static bool IsNullableOfT(Type type, ref Type elementType)
        {
            if (IsNullableOfT(type))
            {
                elementType = type.GetTypeInfo().GenericTypeArguments[0];
                return true;
            }
            else
            {
                elementType = null;
                return false;
            }
        }

        /// <summary>
        /// Determine if the specified type implements either <see cref="System.Collections.IEnumerable"/>
        /// or <see cref="System.Collections.Generic.IEnumerable{T}"/>. 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="elementType"></param>
        /// <returns></returns>
        /// <remarks> If the specified type implements <see cref="System.Collections.Generic.IEnumerable{T}"/>
        /// then the element (T) type will be assigned to elementType. If the function returns true
        /// but elementType is null, it means the type implements <see cref="System.Collections.IEnumerable"/>
        /// but not <see cref="System.Collections.Generic.IEnumerable{T}"/>
        /// </remarks>
        public static bool IsEnumerable(Type type, ref Type elementType)
        {
            return IsEnumerable(type, false, ref elementType);
        }

        /// <summary>
        /// Determine if the specified type implements either <see cref="System.Collections.IEnumerable"/>
        /// or <see cref="System.Collections.Generic.IEnumerable{T}"/>. 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="excludeString">Whether to exclude <see cref="string" /> </param>
        /// <param name="elementType"></param>
        /// <returns></returns>
        /// <remarks> If the specified type implements <see cref="System.Collections.Generic.IEnumerable{T}"/>
        /// then the element (T) type will be assigned to elementType. If the function returns true
        /// but elementType is null, it means the type implements <see cref="System.Collections.IEnumerable"/>
        /// but not <see cref="System.Collections.Generic.IEnumerable{T}"/>
        /// </remarks>
        public static bool IsEnumerable(Type type, bool excludeString, ref Type elementType)
        {
            if (excludeString && (type == typeof(string))) return false;
            Type[] typeParams = null;
            if (Implements(type, typeof(IEnumerable<>), ref typeParams))
            {
                elementType = typeParams[0];
                return true;
            }
            else
            {
                elementType = null;
                return Implements(type, typeof(System.Collections.IEnumerable));
            }
        }

        /// <summary>
        /// Determine if the specified type implements a particular interface
        /// </summary> 
        public static bool Implements(Type type, Type interfaceType)
        {
            Type[] typeParams = null;
            return Implements(type, interfaceType, ref typeParams);
        }

        /// <summary>
        /// Determine if the specified type implements a particular interface
        /// </summary> 
        /// <remarks> If interface is an open generic interface and type is a constructed
        /// version of it, typeArguments will contain the array of generic type parameters
        /// </remarks>
        public static bool Implements(Type type, Type interfaceType, ref Type[] typeArguments)
        {
            var typeInfo = type.GetTypeInfo();
            var interfaceInfo = interfaceType.GetTypeInfo();

            typeArguments = null;
            if (!interfaceInfo.IsInterface) throw new ArgumentException("interface must be an interface type");

            var allInterfaces = typeInfo.ImplementedInterfaces.ToList();
            if (type.GetTypeInfo().IsInterface) allInterfaces.Insert(0, type);

            if (interfaceInfo.IsGenericTypeDefinition)
            {
                foreach (Type implementedInterface in allInterfaces)
                {
                    if (interfaceInfo.IsGenericType)
                    {
                        Type interfaceTypeDef = implementedInterface.GetGenericTypeDefinition();
                        if (interfaceTypeDef == interfaceType)
                        {
                            typeArguments = interfaceInfo.GenericTypeArguments;
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return allInterfaces.Contains(interfaceType);
            }
        }

        /// <summary>
        /// Determine if the specified type is a constructed generic of a given generic type definition
        /// </summary>  
        public static bool IsConstructedType(Type type, Type genericTypeDefinition)
        {
            Type[] typeArray = null;
            return TypeUtil.IsConstructedType(type, genericTypeDefinition, ref typeArray);
        }

        /// <summary>
        /// Determine if the specified type is a constructed generic of a given generic type definition. If 
        /// true, the array of generic type parameters is returned in typeArguments.
        /// </summary>  
        public static bool IsConstructedType(Type type, Type genericTypeDefinition, ref Type[] typeArguments)
        {
            var genericInfo = genericTypeDefinition.GetTypeInfo();
            if (!genericInfo.IsGenericTypeDefinition)
            {
                throw new ArgumentException("genericTypeDefinition must be a generic type definition");
            }
            if (genericInfo.IsGenericType)
            {
                if (type.GetGenericTypeDefinition() == genericTypeDefinition)
                {
                    typeArguments = genericInfo.GenericTypeArguments;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Return the default value of any type. Equivalent to the C# generic keyword default(T)
        /// </summary> 
        public static object Default(Type type)
        {
            if (type.GetTypeInfo().IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                return null;
            }
        }

#if NETSTANDARD1_3
        /// <summary>
        /// Determine if the provided value is an instance of the provided type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static bool IsInstanceOfType(Type type, object value)
        {
            if (value == null) return false;
            Type valType = value.GetType();
            return valType == type || valType.GetTypeInfo().IsSubclassOf(type);
        }
#else
        internal static bool IsInstanceOfType(Type type, object value)
        {
            return type.IsInstanceOfType(value);
        }
#endif

    }
}
