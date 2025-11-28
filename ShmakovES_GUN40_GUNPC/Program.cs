using System.Text;

class Program
{

    static void Main(string[] args)
    {
        string name = "Ivan";
        int age = 25;
        string[] words = { "words1", "words2", "words3", "words4", "words5", "words6" };
        string word1 = "world";
        string word2 = "internet";
        string inputString = "Hello world";
        string string1 = "afA  sad fHGJ  IYVG KJIYKafdad";
        string string2 = " SDEfvghsjkvbkbsujf szk u";
        ConcatenateString( string1, string2 );  //1
        GreetUser(name, age);                   //2
        SortingSimbol(string1);                 //3
        ReturnFive(string1);                    //4
        StringAdd(words);                       //5
        ReplaceWords(inputString, word1, word2);//6
    }
    static void  ConcatenateString(string str1, string str2)
    {
        
        str1 = str1.Insert(str1.Length, str2);
        Console.WriteLine(str1);
    }

    static void GreetUser(string name, int age)
    {
        string textString = $"Hello, {name}! \nYou are {age} years old.";
        Console.WriteLine(textString);
    }

    static void SortingSimbol(string str)
    {
        Console.WriteLine("Количество символов в строке: ",str.Length);
        var up = str.Where(char.IsUpper);
            Console.WriteLine($"Символы верхнего регистра: {string.Join(" ", up)}");
        var down = str.Where(char.IsLower);
        Console.WriteLine($"Символы нижнего регистра: {string.Join(" ", down)}");
    }

    static void ReturnFive(string text)
    {
        string result = text.Substring(0, 5);
        Console.WriteLine("Первые 5 символов строки: "+result);
    }

    static void StringAdd(string[] words)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string word in words)
        {
            stringBuilder.Append(word+" ");
        }
        string result = stringBuilder.ToString();
        Console.WriteLine(result);
    }

    static void ReplaceWords(string inputString, string wordToReplace, string replacementWord)
    {
        string result = inputString.Replace(wordToReplace, replacementWord);
        Console.WriteLine(result);
    }
}
