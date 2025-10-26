class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first decimal number:");
        if (!Int32.TryParse(Console.ReadLine(), out var a))        
        {
            Console.WriteLine("Not a number!");
            return;
        }
        Console.WriteLine("Enter second decimal number:");
        if (!Int32.TryParse(Console.ReadLine(), out var b))        
        {
            Console.WriteLine("Not a number!");
            return;
        }
        Console.WriteLine("Enter comand '&', '|' or '^':");

        var s = Console.ReadLine();
        if ((s == "&") || (s == "|")|| (s == "^"))
        {
            switch (s[0])
            {
            case '&':
                Console.WriteLine("Result of logical multiplication:");
                Console.WriteLine("Binare:  {0} & {1} = {2}", Convert.ToString(a,2), Convert.ToString(b, 2), Convert.ToString((a & b), 2));
                Console.WriteLine("Decimal: {0} & {1} = {2}", a, b, a & b);
                Console.WriteLine("Hex:     {0} & {1} = {2}", Convert.ToString(a, 16), Convert.ToString(b, 16), Convert.ToString((a & b), 16));
                break;
            case '|':
                Console.WriteLine("Result of logical addition:");
                Console.WriteLine("Binare:  {0} | {1} = {2}", Convert.ToString(a, 2), Convert.ToString(b, 2), Convert.ToString((a | b), 2));
                Console.WriteLine("Decimal: {0} | {1} = {2}", a, b, a | b);
                Console.WriteLine("Hex:     {0} | {1} = {2}", Convert.ToString(a, 16), Convert.ToString(b, 16), Convert.ToString((a | b), 16));
                break;
            case '^':
                Console.WriteLine("Result of the operation of the exclusive OR:");
                Console.WriteLine("Binare:  {0} ^ {1} = {2}", Convert.ToString(a, 2), Convert.ToString(b, 2), Convert.ToString((a ^ b), 2));
                Console.WriteLine("Decimal: {0} ^ {1} = {2}", a, b, a ^ b);
                Console.WriteLine("Hex:     {0} ^ {1} = {2}", Convert.ToString(a, 16), Convert.ToString(b, 16), Convert.ToString((a ^ b), 16));
                break;
            }
           
        }
        else
        {
            Console.WriteLine("Wrong sign");
            return;
        }
        

    }
}
