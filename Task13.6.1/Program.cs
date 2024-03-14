using System.Diagnostics;

namespace ModuleApp13;

class Program
{
    static void Main(string[] args)
    {
        string[] splitedText = GetSplitedText();

        Console.WriteLine($"Время вставки в List<T>: {TestingList(new Stopwatch(), splitedText)} ms");
        Console.WriteLine($"Время вставки в LinkedList<T>: {TestingLinkedList(new Stopwatch(), splitedText)} ms");
    }

    static string[] GetSplitedText()
    {
        string text;
        char[] separators = { ' ', '\n', '\r' };

        using (StreamReader sr = new StreamReader(@"C:\Users\Никонов\OneDrive\Рабочий стол\Obl.txt"))
        {
            text = sr.ReadToEnd();
        }

        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        return noPunctuationText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }

    static long TestingList(Stopwatch stopwatch, string[] array)
    {
        var list = new List<string>(array);
        var middleIndx = list.Count / 2;

        stopwatch.Start();

        for(int i = 0; i < array.Length; i++)
        {
            list.Insert(middleIndx + i, array[i]);
        }

        stopwatch.Stop();

        Console.WriteLine($"Кол-во элементов после вставки в List<T>: {list.Count}");

        return stopwatch.ElapsedMilliseconds;
    }

    static long TestingLinkedList(Stopwatch stopwatch, string[] array)
    {
        var linkedList = new LinkedList<string>(array);
        LinkedListNode<string> middleNode = linkedList.First;

        for(int i = 0; i < linkedList.Count / 2; i++)
        {
            middleNode = middleNode.Next;
        }

        stopwatch.Start();

        foreach (var item in array)
        {
            linkedList.AddAfter(middleNode, item);
            middleNode = middleNode.Next;
        }

        stopwatch.Stop();

        Console.WriteLine($"Кол-во элементов после вставки в LinkedList<T>: {linkedList.Count}");

        return stopwatch.ElapsedMilliseconds;
    }
}