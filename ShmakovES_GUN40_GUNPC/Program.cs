class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Task A");
        Console.WriteLine("Task 1");
        int[] fibonachi = new int[] { 0, 1 };
        Array.Resize(ref fibonachi, 8);
        for(int i =0; i< fibonachi.Length; i++)
        {
            if (i >= 2)
            {
                fibonachi[i] = fibonachi[i - 2] + fibonachi[i - 1];
            }
            Console.Write(fibonachi[i]+ " ");
        }
        Console.WriteLine();
        Console.WriteLine("==========");
        Console.WriteLine("Task 2");
        string[] months = new string[] { "January", "Feruary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
        for (int i = 0; i < months.Length; i++)
        {
            Console.WriteLine(months[i]);
        }
        Console.WriteLine("==========");
        Console.WriteLine("Task 3");

        int[,] matrix = new int[3,3];

        for(int i=0; i<matrix.GetLength(0); i++)
        {
            
            for (int j=0; j<matrix.GetLength(1);j++)
            {
                matrix[i, j] = (int)Math.Pow((j + 2), (i + 1));
                Console.Write(matrix[i, j]+" ");
            }
            Console.WriteLine();
        }       
        Console.WriteLine("==========");
        Console.WriteLine("Task 4");

        
        double[][] array = new double[3][];
        array[0] = new double[5];
        array[1] = new double[2];
        array[2] = new double[4];

        for(int i=0;i<4;i++)
        {
            array[0][i] = i+1;
        }
       

        array[1][0] = Math.Exp(1);
        array[1][1] =  Math.PI;


        array[2][0] = Math.Log10(1);
        array[2][1] = Math.Log10(10);
        array[2][2] = Math.Log10(100);
        array[2][3] = Math.Log10(1000);
        
        for(int i=0; i < array.Length; i++)
        {
            for(int j=0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("Task B");
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 7, 8, 9, 10, 11, 12, 13 };

        Console.WriteLine("Task 5");

        Array.Copy(array1, array2, 3);

        for (int i = 0; i < array2.Length; i++)
        {
            Console.Write(array2[i]+" ");
        }
        Console.WriteLine();
        Console.WriteLine("==========");
        Console.WriteLine("Task 6");
        Array.Resize(ref array1, array1.Length * 2);

        for(int i =0; i< array1.Length; i++)
        {
            Console.Write(array1[i]+" ");
        }
    }
}
