
class Program
{

    private static void Counter(object oDelay)
    {
        ulong counter = 0;

        int iDelay = (int)(oDelay ?? 100);

        try
        {
            while (true)
            {
                Console.Out.WriteLineAsync($"Thread #{Thread.CurrentThread.ManagedThreadId}: {counter++}");

                Thread.Sleep(iDelay);
            }
        }
        catch (ThreadInterruptedException)
        {
            // Ignore
        }
    }


    static void Main(string[] args)
    {
        #region Old School
        Thread t1 = new Thread(Counter) { IsBackground = true };
        Thread t2 = new Thread(Counter) { IsBackground = true }; ;

        t1.Start(321);
        t2.Start(123);

        Thread.Sleep(5000);

        // t1.Interrupt();
        // t2.Interrupt();
        #endregion

        //---------------------------------------------------------------------

        #region New Style

        // Task t1 = Task.Run(() => Counter(321));
        // Task t2 = Task.Run(() => Counter(123));

        // Thread.Sleep(5000);

        #endregion
    }
}