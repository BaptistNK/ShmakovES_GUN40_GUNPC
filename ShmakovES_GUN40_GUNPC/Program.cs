using ShmakovES_GUN40_GUNPC;
using System;

class Program
{
    
    static void Main(string[] args)
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();
            Console.WriteLine("Выберите задание: 1, 2 или 3");
            string task = Console.ReadLine();
            if (task == "-exit")
            {
                exitProgram = true;
                continue;
            }

            if (int.TryParse(task, out int number))
            {
                switch (number)
                {
                    case 1:
                        Task1 task1 = new Task1();
                        task1.TaskLoop();
                        break;
                    case 2:
                        Task2 task2 = new Task2();
                        task2.TaskLoop();
                        break;
                    case 3:
                        Task3 task3 = new Task3();
                        task3.TaskLoop();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод! ");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
                
            }
        }

        
    }
}

public class Task1
{
public void TaskLoop()
    {
        var list = new List<string>() { "afda", "asefase", "seafeasf"};
        Console.WriteLine("Введите строку");
        list.Add(Console.ReadLine());
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
        Console.WriteLine("Введите еще одну строку");
        int sum = Convert.ToInt32(Math.Round(Convert.ToDecimal(list.Count / 2)));
        string str = Console.ReadLine();
        list.Insert(sum, str);
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
        Console.WriteLine("Программа выполена. Нажмите на любую кнопку.");
        string input = Console.ReadLine();
    }
}
public class Task2
{
    
    
    public void TaskLoop()
    {
        Dictionary<string, int> students = new Dictionary<string, int>();
        students.Add("Иван", 3);
        students.Add("Олег", 5);
        students.Add("Стас", 4);
        Console.WriteLine("Введите имя студента:");
        string name = Console.ReadLine();
        Console.WriteLine("Введите среднюю оценку от 2 до 5:");        
        string input = Console.ReadLine();
        if(int.TryParse(input, out int score))
        {
            if (score >= 2 && score <= 5) 
            { 
                students.Add(name, score);
            }
            else
            {
                Console.WriteLine("Введена некорректная оценка!");
                Console.ReadKey();
                return;
            }
        }

        foreach (KeyValuePair<string, int> pair in students)
        {
            Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
        }
        Console.WriteLine("Введите имя студента");
        name = Console.ReadLine();
        if(students.ContainsKey(name))
        {
            //score = students[name];
            Console.WriteLine(name+ " с оценкой "+ score);
        }
        else
        {
            Console.WriteLine("Имя не найдено");
        }
        Console.WriteLine("Программа выполнена. Нажмите любую кнопку.");
        Console.ReadKey();
    }
}
public class Task3
{
    private class Node
    {
        public int value;
        public Node Preview;
        public Node Next;        
    }
    public void TaskLoop()
    {
        var duplexList = new DuplexLinkedList<string>();
        Console.WriteLine("Введите от 3 до 6 элементов: ");
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                break;
            duplexList.Add(input);
        }
        Console.WriteLine("<====Result===>");
        foreach (var item in duplexList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("====Reverse===");
        var reverse = duplexList.Reverse();
        foreach(var item in reverse)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Программа выполнена. Нажмите любую кнопку.");
        Console.ReadKey();
    }
}
public class DuplexItem<T>
{
    public T Data {  get; set; }
    public DuplexItem<T> Previous { get; set; }
    public DuplexItem<T> Next { get; set; }

    public DuplexItem(T data)
    {
        Data = data;
    }
    public override string ToString()
    {
        return Data.ToString();
    }
}
