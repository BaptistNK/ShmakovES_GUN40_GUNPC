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
        
        Console.WriteLine(ConcatenateString(string1, string2));     //1        
        Console.WriteLine(GreetUser(name, age));                    //2                      
        Console.WriteLine(SortingSimbol(string2));                  //3
        Console.WriteLine(ReturnFive(string1));                     //4
        Console.WriteLine(StringAdd(words));                        //5
        Console.WriteLine(ReplaceWords(inputString, word1, word2)); //6
    }
    static string  ConcatenateString(string str1, string str2)
    {
        return str1+str2;
    }

    static string GreetUser(string name, int age)
    {
        return $"Hello, {name}! \nYou are {age} years old.";
    }

    static string SortingSimbol(string str)
    {
        var up = str.Where(char.IsUpper);
        var down = str.Where(char.IsLower);
        return $"Количество символов в строке: { str.Length} \nСимволы верхнего регистра: {string.Join(" ", up)} \nСимволы нижнего регистра: {string.Join(" ", down)}";        
    }

    static string ReturnFive(string text)
    {
        return text.Substring(0, 5);
    }

    static string StringAdd(string[] words)
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string word in words)
        {
            stringBuilder.Append(word+" ");
        }
        return stringBuilder.ToString();        
    }

    static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
    {
        return inputString.Replace(wordToReplace, replacementWord);
    }
}
