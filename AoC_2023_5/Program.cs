using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        StreamReader r = new StreamReader("input.txt");
        {
            StreamWriter w = new StreamWriter("output.txt");
            {
                string input = r.ReadLine();
                string[] inputAr = input.Split();
                Queue<(long, long)> seeds = new Queue<(long, long)>();
                for(int i = 1; i <inputAr.Length; i+=2) 
                {
                    seeds.Enqueue((long.Parse(inputAr[i]), long.Parse(inputAr[i + 1])));
                }
                r.ReadLine();
                r.ReadLine();
                input = r.ReadLine();
                while (input != null)
                {
                    Queue < (long, long) > newSeeds = new Queue<(long, long)>();
                    while (input != ""&&input!=null)
                    {
                        inputAr = input.Split();
                        long start = long.Parse(inputAr[1]);
                        long toStart = long.Parse(inputAr[0]);
                        long len = long.Parse(inputAr[2]);
                        Queue < (long, long)> newQueue = new Queue<(long, long)>();
                        while(seeds.Count > 0) 
                        { 
                            (long, long) current = seeds.Dequeue();
                            long beg = current.Item1;
                            long l = current.Item2;
                            if (start <= beg && start + len >= beg + l)
                            {
                                newSeeds.Enqueue((beg + toStart - start, l));
                            }
                            else if (start > beg && start + len < beg + l)
                            {

                                newSeeds.Enqueue((toStart, len));
                                newQueue.Enqueue((beg, start - beg));
                                newQueue.Enqueue((start + len, beg + l - (start + len)));
                            }
                            else if (start > beg && start<beg+l) 
                            {
                                newSeeds.Enqueue((toStart, beg+l-start));
                                newQueue.Enqueue((beg, start - beg));
                            }
                            else if(start+len>beg && start + len < beg + l)
                            {
                                newSeeds.Enqueue((beg + toStart - start, start+len-beg));
                                newQueue.Enqueue((start + len, beg + l - (start + len)));
                            }
                            else
                            {
                                newQueue.Enqueue(current);
                            }
                        }
                        while(newQueue.Count > 0)
                        {
                            seeds.Enqueue(newQueue.Dequeue());
                        }
                        input = r.ReadLine();
                    }
                    r.ReadLine();
                    while (newSeeds.Count > 0)
                    {
                        seeds.Enqueue(newSeeds.Dequeue());
                    }
                    input = r.ReadLine();
                }
                long min = seeds.ToList().Min(a=>a.Item1);
                Console.WriteLine(min);
            }
        }
    }

    public static void Easy(StreamReader r, StreamWriter w)
    {
        string input = r.ReadLine();
        string[] inputAr = input.Split();
        long[] seeds = new long[inputAr.Length - 1];
        for (int i = 0; i < seeds.Length; i++)
        {
            seeds[i] = long.Parse(inputAr[i + 1]);
        }
        r.ReadLine();
        r.ReadLine();
        input = r.ReadLine();
        while (input != null)
        {
            long[] newSeeds = seeds.ToArray();
            while (input != "" && input != null)
            {
                inputAr = input.Split();
                long start = long.Parse(inputAr[1]);
                long toStart = long.Parse(inputAr[0]);
                long len = long.Parse(inputAr[2]);
                for (int i = 0; i < seeds.Length; i++)
                {
                    if (seeds[i] >= start && seeds[i] <= (start + len))
                    {
                        newSeeds[i] = seeds[i] + toStart - start;
                    }
                }
                input = r.ReadLine();
            }
            r.ReadLine();
            for (int i = 0; i < newSeeds.Length; i++)
            {
                seeds[i] = newSeeds[i];
            }
            input = r.ReadLine();
        }
        long min = seeds.Min();
        Console.WriteLine(min);
    }

    public static List<long> EasyMap(List<int> seeds, List<(int, int, int)> map)
    {
        List<long> returnList = new List<long>();
        foreach((int, int, int) line in map)
        {
            long destinationStart = line.Item1;
            long sourceStart = line.Item2;
            long len = line.Item3;
            for (int i  = 0; i<seeds.Count; i++)
            {
                if(seeds[i]>= sourceStart && seeds[i]< sourceStart + len)
                {
                    returnList.Add(destinationStart+seeds[i]-sourceStart);
                    seeds.RemoveAt(i);
                    i--;
                }
            }
        }
        foreach (int i in seeds)
        {
            returnList.Add(i);
        }
        return returnList;
  
    }

    public static List<long> ParseSeedsEasy(string input)
    {
        string[] inputAr = input.Split();
        long[] seeds = new long[inputAr.Length - 1];
        for (int i = 0; i < seeds.Length; i++)
        {
            seeds[i] = long.Parse(inputAr[i + 1]);
        }
        return seeds.ToList();
    }

    public static List<(int, int, int)> ParseMapEasy(List<string> input) 
    { 
        throw new NotImplementedException(); 
    }
}