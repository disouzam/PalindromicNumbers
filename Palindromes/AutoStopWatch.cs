// Reference:
// https://stackoverflow.com/questions/3903222/measure-execution-time-in-c-sharp
// Answer by https://stackoverflow.com/users/435383/katbyte

using System;
using System.Diagnostics;
using System.Threading;

namespace Palindromes.Diagnostic;

public class AutoStopWatch : Stopwatch, IDisposable
{

    public AutoStopWatch()
    {
        Start();
    }

    public virtual void Dispose()
    {
        Stop();
    }
}

public class AutoStopWatchConsole : AutoStopWatch
{

    private readonly string prefix;

    public AutoStopWatchConsole(string prefix = "")
    {
        this.prefix = prefix;
    }

    public override void Dispose()
    {
        base.Dispose();

        var format = Elapsed.Days > 0 ? "{0} days " : "";
        format += "{1:00}:{2:00}:{3:00}.{4:00}";

        Console.WriteLine(prefix + " " + string.Format(format, Elapsed.Days, Elapsed.Hours, Elapsed.Minutes, Elapsed.Seconds, Elapsed.Milliseconds / 10));
    }
}

public static class AutoStopWatchUsage
{
    private static void Usage()
    {
        Console.WriteLine("AutoStopWatch Used: ");
        using (var sw = new AutoStopWatch())
        {
            Thread.Sleep(3000);

            Console.WriteLine(sw.Elapsed.ToString("h'h 'm'm 's's'"));
        }

        Console.WriteLine("AutoStopWatchConsole Used: ");
        using (var sw = new AutoStopWatchConsole())
        {
            Thread.Sleep(3000);
        }
    }
}
