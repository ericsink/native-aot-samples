using System;
using System.Runtime.InteropServices;

static class MulCsPinvoke
{
    [DllImport("mul")]
    static extern int multiply(int a, int b);

    public static void Main()
    {
        var c = multiply(7, 6);

        Console.WriteLine($"{c}");
    }
}

