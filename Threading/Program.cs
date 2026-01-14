namespace Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Start Main");
        // Console.WriteLine("Main Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        // Thread thread1 = new Thread(new ThreadStart(Function1));
        // thread1.Start();
        // Console.WriteLine("Main Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        // Thread thread2 = new Thread(new ThreadStart(Function2));
        // thread2.Start();
        // Console.WriteLine("Main Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        MyAsyncFunction();
        Console.WriteLine("End Main");
        
    }

    
    static async Task MyAsyncFunction()
    {
        await Task.Run(() => Function1());
        await Task.Run(() => Function2());
    }
    static void Function1()
    {
        Console.WriteLine("Start Function1");
        Console.WriteLine("Function1 Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("End Function1");
    }

    static void Function2()
    {
        Console.WriteLine("Start Function2");
        Console.WriteLine("Function2 Thread ID: " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("End Function2");
    }
}