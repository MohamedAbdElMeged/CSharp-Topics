using System.ComponentModel;

namespace GarbageCollection;

class Program
{
    static void Main(string[] args)
    {
        long memoryUsage = GC.GetTotalMemory(false);
        Console.WriteLine("Memory usage: {0} bytes", memoryUsage);
        byte[] data = new byte[100_000]; 
        for (int i = 0; i < 1000; i++)
        {
            DoWork(data);
        }
        memoryUsage = GC.GetTotalMemory(false);
        Console.WriteLine("Memory usage: {0} bytes", memoryUsage);


    }
    

    static void DoWork(byte[] data)
    {
        Console.WriteLine("DoWork");
    }
}