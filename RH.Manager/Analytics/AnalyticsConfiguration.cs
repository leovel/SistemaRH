using System;
using System.Linq;
using Microsoft.Win32;

namespace RH.Manager.Analytics
{
    internal class AnalyticsConfiguration
    {
        static AnalyticsConfiguration()
        {
            IsAnalyticsDisabledInRegistry = IsAnalyticsGloballyDisabled();
        }

        public static bool IsAnalyticsDisabledInRegistry
        {
            get;
            private set;
        }

        private static bool IsAnalyticsGloballyDisabled()
        {
            // Analytics is disabled if the registry value [HKLM\Software\Telerik]DisableAnalytics
            // or the value [HKLM\Software\Wow6432Node\Telerik]DisableAnalytics (64-bit process only)
            // exists, is convertible to an integer and is different from "0"
            const string ValueName = "DisableAnalytics";

            using (var nativeKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Telerik"))
                if (IsValueTrue(nativeKey, ValueName))
                    return true;

            if (IntPtr.Size == 8)
            {
                // if this is a 64-bit process then check the 32-bit Wow64 key
                using (var otherKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Telerik"))
                    if (IsValueTrue(otherKey, ValueName))
                        return true;
            }

            return false;
        }

        private static bool IsValueTrue(RegistryKey key, string valueName)
        {
            // if key doesn't exist then the value isn't set, so it's false
            if (key == null)
                return false;

            // if key exists but the value doesn't exist, then it's false
            var value = key.GetValue(valueName);
            if (value == null)
                return false;

            // if the value is of a string type, then parse it as an int and see if it's different from 0
            var asString = value as string;
            if (asString != null)
            {
                int intValue;
                return int.TryParse(asString, out intValue) && intValue != 0;
            }

            // it may be REG_DWORD, cast it and see if it's different from 0
            if (value is int)
            {
                return ((int)value) != 0;
            }

            var nullableInt = value as int?;
            if (nullableInt != null && nullableInt.HasValue)
                return nullableInt.Value != 0;

            // it may be REG_QWORD, cast it and see if it's different from 0
            if (value is long)
            {
                return ((long)value) != 0;
            }

            var nullableLong = value as long?;
            if (nullableLong != null && nullableLong.HasValue)
                return nullableLong.Value != 0;

            // the value exists but is of an unsupported type. Assume this means 'true'
            return true;
        }
    }
}
