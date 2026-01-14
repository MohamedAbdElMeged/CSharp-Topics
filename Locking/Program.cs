namespace Locking;

class Program
{
    private static readonly object _lock = new object();
    static void Main(string[] args)
    {
        lock (_lock)
        {
            // Access shared resource
        }
    }
}