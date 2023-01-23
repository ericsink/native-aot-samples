using System;
using System.Runtime.InteropServices;

public static class NativeExports
{
    [UnmanagedCallersOnly(EntryPoint = "multiply")]
    public static int multiply(int a, int b)
    {
        try
        {
            return a * b;
        }
        catch 
        {
            // TODO this function has no way to propagate errors
            return -1;
        }
    }
}

