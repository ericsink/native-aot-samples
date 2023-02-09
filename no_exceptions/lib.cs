using System;
using System.Runtime.InteropServices;

public static class NativeExports
{
    [UnmanagedCallersOnly(EntryPoint = "get_string_length")]
    public static int GetStringLength(IntPtr v)
    {
        GCHandle h = GCHandle.FromIntPtr(v);
        object ob = h.Target;
        string s = (string) ob;
        int len = s.Length;
        return len;
    }

    [UnmanagedCallersOnly(EntryPoint = "my_function")]
    public static int my_function()
    {
        try
        {
            // do something
            return 0; // 0 means no error
        }
        catch (Exception e)
        {
            return -1; // TODO some kind of meaningful error code
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "get_string_length_errcode_parm")]
    public unsafe static int WithErrorCodeParm(IntPtr v, int* ptr_error_code)
    {
        try
        {
            GCHandle h = GCHandle.FromIntPtr(v);
            object ob = h.Target;
            string s = (string) ob;
            int len = s.Length;
            *ptr_error_code = 0; // no error
            return len;
        }
        catch (Exception e)
        {
            *ptr_error_code = -1; // TODO meaningful error code
            return -1; // TODO but what result should we return?
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "get_string_length_neg")]
    public static int AsNegativeLength(IntPtr v)
    {
        try
        {
            GCHandle h = GCHandle.FromIntPtr(v);
            object ob = h.Target;
            string s = (string) ob;
            int len = s.Length;
            return len;
        }
        catch (Exception e)
        {
            return -1; // TODO meaningful negative error code
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "get_string_length_ex_parm")]
    public unsafe static int WithExceptionParm(IntPtr v, IntPtr* ptr_ex)
    {
        try
        {
            GCHandle h = GCHandle.FromIntPtr(v);
            object ob = h.Target;
            string s = (string) ob;
            int len = s.Length;
            *ptr_ex = IntPtr.Zero; // no error
            return len;
        }
        catch (Exception e)
        {
            *ptr_ex = GCHandle.ToIntPtr(GCHandle.Alloc(e));
            return -1; // TODO but what result should we return?
        }
    }

}

