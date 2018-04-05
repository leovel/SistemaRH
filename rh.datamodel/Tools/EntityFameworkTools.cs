using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace RH.DataModel.Tools
{
    public static class EntityFameworkTools
    {
        /// <summary>
        /// Gets all enum values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>String array of all enum values</returns>
        public static string[] GetEnumValuesAsString(Type enumType)
        {
            object[] values = EntityFameworkTools.GetEnumValues(enumType);
            List<string> valuesAsString = new List<string>();

            foreach (object value in values)
                valuesAsString.Add(value.ToString());

            return valuesAsString.ToArray();
        }

        /// <summary>
        /// Gets all enum values.
        /// </summary>
        /// <param name="enumType">Type of the enum.</param>
        /// <returns>Object array of all enum values</returns>
        public static object[] GetEnumValues(Type enumType)
        {
            List<object> values = new List<object>();

            IEnumerable<FieldInfo> fields = from field in enumType.GetFields()
                                            where field.IsLiteral
                                            select field;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(enumType);
                values.Add(value);
            }

            return values.ToArray();
        }
        public static bool SetProperties<Ts, Td>(Ts sourceObject, Td destinationObject, ICollection<string> includedProperties = null, bool exclude = false)
            where Ts : class
            where Td : class
        {
            var result = false;
            if ((sourceObject == null) || (destinationObject == null)) return false;
            Type surceType = sourceObject.GetType();
            Type destinationType = destinationObject.GetType();
            foreach (PropertyInfo sourcePropertyInfo in surceType.GetProperties())
            {
                PropertyInfo destinationPropertyInfo = ((sourcePropertyInfo != null) && sourcePropertyInfo.CanRead) ? destinationType.GetProperty(sourcePropertyInfo.Name, sourcePropertyInfo.PropertyType) : null;
                if (destinationPropertyInfo != null && destinationPropertyInfo.CanWrite && (destinationPropertyInfo.PropertyType.Equals(sourcePropertyInfo.PropertyType)))
                {
                    if (((includedProperties != null) && (includedProperties.Contains(sourcePropertyInfo.Name) != exclude)) || includedProperties == null)
                    {
                        var sourceValue = sourcePropertyInfo.GetValue(sourceObject);
                        var destinationValue = destinationPropertyInfo.GetValue(destinationObject);
                        if((sourceValue == null && destinationValue != null) || (sourceValue != null && !sourceValue.Equals(destinationValue)))
                        {
                            destinationPropertyInfo.SetValue(destinationObject, sourceValue);
                            result = true;
                        }

                    }
                }
            }

            return result;
        }

        public static bool CompareProperties<Ts, Td>(Ts sourceObject, Td destinationObject, ICollection<string> includedProperties = null, bool exclude = false)
            where Ts : class
            where Td : class
        {
            if ((sourceObject == null) || (destinationObject == null)) return false;
            Type surceType = sourceObject.GetType();
            Type destinationType = destinationObject.GetType();
            foreach (PropertyInfo sourcePropertyInfo in surceType.GetProperties())
            {
                PropertyInfo destinationPropertyInfo = ((sourcePropertyInfo != null) && sourcePropertyInfo.CanRead) ? destinationType.GetProperty(sourcePropertyInfo.Name, sourcePropertyInfo.PropertyType) : null;
                if (destinationPropertyInfo != null && destinationPropertyInfo.CanWrite && (destinationPropertyInfo.PropertyType.Equals(sourcePropertyInfo.PropertyType)))
                {
                    if (((includedProperties != null) && (includedProperties.Contains(sourcePropertyInfo.Name) != exclude)) || includedProperties == null)
                    {
                        var sourceValue = sourcePropertyInfo.GetValue(sourceObject);
                        var destinationValue = destinationPropertyInfo.GetValue(destinationObject);
                        if ((sourceValue == null && destinationValue != null) || (sourceValue != null && !sourceValue.Equals(destinationValue)))
                        {
                            return false;
                        }

                    }
                }
            }

            return true;
        }

        public static bool CheckProperties<TIn>(TIn input, ICollection<string> includedProperties = null, bool exclude = false)
            where TIn : class
        {
            if (input == null) return false;
            Type inType = input.GetType();

            bool result = true;

            foreach (PropertyInfo info in inType.GetProperties())
            {
                if ((((includedProperties != null) && (includedProperties.Contains(info.Name) != exclude)) || includedProperties == null)
                    && (info.CanRead && (info.GetValue(input) == null || (string.IsNullOrWhiteSpace(info.GetValue(input).ToString())))))
                    result = false;
            }

            return result;
        }

    }
}
