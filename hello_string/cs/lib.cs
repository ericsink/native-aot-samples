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

    [UnmanagedCallersOnly(EntryPoint = "get_string_length")]
    public static int GetStringLength(IntPtr v)
    {
        GCHandle h = GCHandle.FromIntPtr(v);
        object ob = h.Target;
        string s = (string) ob;
        int len = s.Length;
        return len;
    }

    [UnmanagedCallersOnly(EntryPoint = "banish_letter_l")]
    public static IntPtr BanishLetterL(IntPtr v)
    {
        var s = (string) GCHandle.FromIntPtr(v).Target;
        var s2 = s.Replace("l", "NOT");
        return GCHandle.ToIntPtr(GCHandle.Alloc(s2));
    }

    [UnmanagedCallersOnly(EntryPoint = "free_object_handle")]
    public static void FreeObjectHandle(IntPtr v)
    {
        GCHandle h = GCHandle.FromIntPtr(v);
        h.Free();
    }

}

