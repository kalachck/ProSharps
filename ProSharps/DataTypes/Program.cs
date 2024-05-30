using System.Runtime.InteropServices;

Type[] types =
{
    typeof(sbyte), typeof(byte), typeof(short), typeof(ushort),
    typeof(int), typeof(uint), typeof(long), typeof(ulong),
    typeof(float), typeof(double), typeof(decimal),
    typeof(char), typeof(bool), typeof(string)
};

Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4}", "Type", "Alias", "Bytes", "Default", "Range");

foreach (Type type in types)
{
    string byteSize = type.IsValueType ? Marshal.SizeOf(type).ToString() : "N/A";
    string defaultValue = type.IsValueType ? Activator.CreateInstance(type).ToString() : "null";
    string range = GetRange(type);
    string alias = GetAlias(type);

    SetConsoleColor(type); // Set the console color based on the type
    Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15} {4}", type.Name, alias, byteSize, defaultValue, range);
    Console.ResetColor(); // Reset color to default after each line
}

static void SetConsoleColor(Type type)
{
    if (type == typeof(string) || type == typeof(char))
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    else if (type == typeof(bool))
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else if (type.IsPrimitive)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
    }
}

static string GetRange(Type type)
{
    if (type == typeof(char))
    {
        var minValue = char.MinValue;
        var maxValue = char.MaxValue;
        return $"\\u{(int)minValue:X4} ('{minValue}') to \\u{(int)maxValue:X4} ('{maxValue}')";
    }

    if (type.IsPrimitive && type != typeof(bool) && type != typeof(string))
    {
        var minValue = type.GetField("MinValue").GetValue(null);
        var maxValue = type.GetField("MaxValue").GetValue(null);
        return $"{minValue} to {maxValue}";
    }

    if (type == typeof(decimal))
    {
        decimal minValue = decimal.MinValue;
        decimal maxValue = decimal.MaxValue;
        return $"{minValue} to {maxValue}";
    }

    return Type.GetTypeCode(type) switch
    {
        TypeCode.Boolean => "True or False",
        TypeCode.String => "N/A",
        _ => "Unknown"
    };
}

static string GetAlias(Type type)
{
    switch (Type.GetTypeCode(type))
    {
        case TypeCode.SByte: return "sbyte";
        case TypeCode.Byte: return "byte";
        case TypeCode.Int16: return "short";
        case TypeCode.UInt16: return "ushort";
        case TypeCode.Int32: return "int";
        case TypeCode.UInt32: return "uint";
        case TypeCode.Int64: return "long";
        case TypeCode.UInt64: return "ulong";
        case TypeCode.Single: return "float";
        case TypeCode.Double: return "double";
        case TypeCode.Decimal: return "decimal";
        case TypeCode.Char: return "char";
        case TypeCode.Boolean: return "bool";
        case TypeCode.String: return "string";
        default: return "N/A";
    }
}
