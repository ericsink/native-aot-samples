using System;
using System.Runtime.InteropServices;

public static class NativeExports
{
    [UnmanagedCallersOnly(EntryPoint = "get_hello_string")]
    public static IntPtr GetHelloString()
    {
        string s = "Hello World";
        GCHandle h = GCHandle.Alloc(s);
        return GCHandle.ToIntPtr(h);
    }

    [UnmanagedCallersOnly(EntryPoint = "free_object_handle")]
    public static void FreeObjectHandle(IntPtr v)
    {
        GCHandle h = GCHandle.FromIntPtr(v);
        h.Free();
    }

}

