using System;
using System.Runtime.InteropServices;

public static class NativeExports
{
    [UnmanagedCallersOnly(EntryPoint = "multiply")]
    public static int multiply(int a, int b)
    {
        return a * b;
    }
}

