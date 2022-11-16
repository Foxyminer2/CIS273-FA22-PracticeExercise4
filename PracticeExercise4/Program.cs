namespace PracticeExercise4;
class Program
{
    static void Main(string[] args)
    {
        var ht = new HashTableLinearProbing<string, int>();

        ht.Add("a", 12);
        ht.Add("b", 12);
        ht.Add("c", 12);
        ht.Add("d", 12);
        ht.Add("e", 12);
        ht.Add("f", 12);
        ht.Add("g", 12);
        ht.Add("h", 12);
        ht.Add("i", 12);
        ht.Add("j", 12);
        ht.Add("k", 12);
        ht.Add("l", 12);
        ht.Add("m", 12);
        ht.Add("n", 12);
        ht.Add("o", 12);
        ht.Add("p", 12);
        ht.Add("q", 12);
        ht.Add("r", 12);
        ht.Add("s", 12);
        ht.Add("t", 12);
        ht.Add("u", 12);
        ht.Add("v", 12);
        ht.Add("w", 12);

        //Console.WriteLine( ht.Count); // should be 23
        Console.WriteLine(ht.GetValues().Count);
    }
}

