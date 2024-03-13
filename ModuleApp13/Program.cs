namespace ModuleApp13;
class Program
{
    static void Main(string[] args)
    {
        string text;
        
        using (StreamReader sr = new StreamReader(@"C:\Users\Никонов\OneDrive\Рабочий стол\Obl.txt"))
        {
            text = sr.ReadToEnd();
        }

        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
        string[] splitedText = GetSplitedText(noPunctuationText);
        
        Console.WriteLine($"Кол-во слов в тексте: {splitedText.Length}\n");

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for(int i = 0; i < splitedText.Length; i++)
        {
            if (!dictionary.ContainsKey(splitedText[i]))
            {
                dictionary.TryAdd(splitedText[i], 1);
                continue;
            }
            dictionary[splitedText[i]]++;
        }

        List<KeyValuePair<string, int>> list = dictionary.ToList();
        list.Sort((x, y) => x.Value.CompareTo(y.Value));

        var FrequentlyUsedWords = list.GetRange(list.Count - 10, 10);
        
        Console.WriteLine($"Самые часто используемые слова в тексте:\n");
        
        foreach (var item in  FrequentlyUsedWords)
            Console.WriteLine($"{item.Key} --> {item.Value}");
    }

    static string[] GetSplitedText(string text)
    {
        char[] separators = { ' ', '\n', '\r' };
        string[] splitedText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        return splitedText;
    }
}