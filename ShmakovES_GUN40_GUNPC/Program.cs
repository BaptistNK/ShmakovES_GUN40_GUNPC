class Program
{
    static void Main(string[] args)
    {
        Task1 task1 = new Task1();
        Task2 task2 = new Task2();
        Task3 task3 = new Task3();

        Console.WriteLine("Выберите задание: 1, 2 или 3");
        string task = Console.ReadLine();
        if (int.TryParse(task, out int number))
        {
            if (number >= 1 && number <= 3)
            {
                switch (number)
                {
                    case 1:
                        task1.TaskLoop();
                        break;
                    case 2:
                        task2.TaskLoop();
                        break;
                    case 3:
                        task3.TaskLoop();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                return;
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
        Console.WriteLine("для выбора задачи введите '-exit'");
        str = Console.ReadLine();
        if(str =="-exit")
        {
            return;
        }
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
             score = students[name];
            Console.WriteLine(name+ " с оценкой "+ score);
        }
        else
        {
            Console.WriteLine("Имя не найдено");
        }
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
        var node1 = new Node() { value = 1};
        
        var node2 = new Node() { value = 2 };
        
        var node3 = new Node() { value = 3 }; 
        
        var node4 = new Node() { value = 4 };
        

        node1.Preview = null;
        node1.Next = node2;
        node2.Preview = node1;
        node2.Next = node3;
        node3.Preview = node2;
        node3.Next = node4;
        node4.Preview = node3;
        node4.Next = null;
        var next = node1;
        while (next != null)
        {
            Console.WriteLine(next.value);
            next = next.Next;
        }



    }
}
