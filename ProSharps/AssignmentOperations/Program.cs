var a = 10;
var b = 3;

var operations = new Dictionary<string, (Action<int, int> Operation, string Description)>
{
    { "A += B", ( (x, y) => x += y, "Присваивание после сложения. Эквивалентно A = A + B.") },
    { "A -= B", ( (x, y) => x -= y, "Присваивание после вычитания. Эквивалентно A = A - B.") },
    { "A *= B", ( (x, y) => x *= y, "Присваивание после умножения. Эквивалентно A = A * B.") },
    { "A /= B", ( (x, y) => x /= y, "Присваивание после деления. Эквивалентно A = A / B.") },
    { "A %= B", ( (x, y) => x %= y, "Присваивание после деления по модулю. Эквивалентно A = A % B.") },
    { "A &= B", ( (x, y) => x &= y, "Присваивание после поразрядной конъюнкции. Эквивалентно A = A & B.") },
    { "A |= B", ( (x, y) => x |= y, "Присваивание после поразрядной дизъюнкции. Эквивалентно A = A | B.") },
    { "A ^= B", ( (x, y) => x ^= y, "Присваивание после операции исключающего ИЛИ. Эквивалентно A = A ^ B.") },
    { "A <<= B", ( (x, y) => x <<= y, "Присваивание после сдвига разрядов влево. Эквивалентно A = A << B.") },
    { "A >>= B", ( (x, y) => x >>= y, "Присваивание после сдвига разрядов вправо. Эквивалентно A = A >> B.") },
};

PrintTableHeader();

foreach (var operation in operations)
{
    PerformOperation(operation.Key, ref a, b, operation.Value.Operation, operation.Value.Description);
    a = 10; // Reset A to initial value for the next operation
}

static void PerformOperation(string operation, ref int a, int b, Action<int, int> func, string description)
{
    var originalA = a;
    func(a, b);
    Console.WriteLine($"| {operation,-10} | {originalA,10} | {b,10} | {a,10} | {description,-75} |");
}

static void PrintTableHeader()
{
    Console.WriteLine(new string('-', 115));
    Console.WriteLine($"| {"Операция",-10} | {"Исходное A",10} | {"B",10} | {"Результат A",10} | {"Описание",-75} |");
    Console.WriteLine(new string('-', 115));
}
