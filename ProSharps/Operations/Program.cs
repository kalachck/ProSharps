var a = 15;
var b = 3;

var operations = new Dictionary<string, (int Result, string Description)>()
{
    ["Addition (a + b)"] = (a + b, "Сложение a и b"),
    ["Subtraction (a - b)"] = (a - b, "Вычитание b из a"),
    ["Multiplication (a * b)"] = (a * b, "Умножение a на b"),
    ["Division (a / b)"] = (a / b, "Деление a на b"),
    ["Modulus (a % b)"] = (a % b, "Остаток от деления a на b"),
    ["AND (a & b)"] = (a & b, "Побитовое И между a и b"),
    ["OR (a | b)"] = (a | b, "Побитовое ИЛИ между a и b"),
    ["XOR (a ^ b)"] = (a ^ b, "Побитовое исключающее ИЛИ между a и b"),
    ["NOT (~a)"] = (~a, "Побитовое НЕ для a"),
    ["Left Shift (a << 1)"] = (a << 1, "Сдвиг влево a на 1 бит"),
    ["Right Shift (a >> 1)"] = (a >> 1, "Сдвиг вправо a на 1 бит")
};

Console.WriteLine("Operands: 3 and 15");
Console.WriteLine("{0,-30} {1,-20} {2,-50}", "Operation", "Result", "Description (RU)");

foreach (var op in operations)
{
    Console.WriteLine("{0,-30} {1,-20} {2,-50}", op.Key, op.Value.Result, op.Value.Description);
}
