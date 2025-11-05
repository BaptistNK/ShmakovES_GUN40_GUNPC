class Program
{
    static void Main(string[] args)
    {
        //Fibonachi
        int[] fibonachi = new int[] { 0, 1 };
        Array.Resize(ref fibonachi, 10);
        for (int i = 0; i < fibonachi.Length; i++)
        {
            if (i >= 2)
            {
                fibonachi[i] = fibonachi[i - 2] + fibonachi[i - 1];
            }
            Console.Write(fibonachi[i] + " ");
        }
        Console.WriteLine();

        //2..4..
        Console.WriteLine();
        int num = 0;
        for (int i = 0; i < 10; i++)
        {
            num = num + 2;
            Console.Write(num + " ");
        }
        //
        Console.WriteLine();

        //multiplication
        Console.WriteLine();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write((i + 1) * (j + 1) + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // password
        string password = "qwerty";
        string userPassword;
        do
        {
            Console.Write("Enter password: ");
            userPassword = Console.ReadLine()!;
            if (userPassword != password)
            {
                Console.WriteLine("Uncorrect password!");
            }
        } while (userPassword != password);

        if (userPassword == password)
        {
            Console.WriteLine("Access is allowed!");
        }
    }
}
