
class Program
{

    public static void Counter(object delay)
    {
        ulong counter = 0;

        int iDelay=(int) delay;

        try
        {
            while (true)
            {
                Console.Out.WriteLineAsync($"{Thread.CurrentThread.ManagedThreadId}: {counter++}");
                 Thread.Sleep(iDelay);
            }
        }
        catch (Exception)
        {

        }
    }


    static void Main(string[] args)
    {
        Thread t1 = new Thread(Counter);
        Thread t2 = new Thread(Counter);

        t1.Start(321);
        t2.Start(123);

        Thread.Sleep(5000);

        t1.Interrupt();
        t2.Interrupt();
    }
}