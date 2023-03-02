namespace cs;

using System.Runtime.InteropServices;

public class Class1
{
    public delegate int MapOne(int x);
    public static int MapSum(
        int n, 
        MapOne f
        )
    {
        var sofar = 0;
        for (var i=0; i<n; i++)
        {
            sofar += f(i);
        }
        return sofar;
    }

    public static int CountDivisibleBy42(int n)
    {
        return MapSum(n, x => ((x % 42) == 0) ? 1 : 0);
    }

    public static int count_files_with_e(string path)
    {
        return System.IO.Directory.GetFiles(path)
            .Where(x => x.Contains("e"))
            .Count()
            ;
    }

    [UnmanagedCallersOnly(EntryPoint = "map_sum_with_funcptr")]
    public static unsafe int MapSumWithFuncPtr(
        int n, 
        delegate* unmanaged<int,int> f
        )
    {
        var sofar = 0;
        for (var i=0; i<n; i++)
        {
            sofar += f(i);
        }
        return sofar;
    }

    private unsafe class my_shadow 
    {
        readonly delegate* unmanaged<int,int> _funcptr;
        public my_shadow(delegate* unmanaged<int,int> funcptr)
        {
            _funcptr = funcptr;
        }
        public unsafe int Invoke(int x)
        {
            return _funcptr(x);
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "create_delegate")]
    public static unsafe IntPtr CreateDelegate(
        delegate* unmanaged<int,int> funcptr
        )
    {
        try
        {
            var shadow = new my_shadow(funcptr);
            var del = Delegate.CreateDelegate(
                typeof(MapOne), 
                shadow, 
                typeof(my_shadow).GetMethod("Invoke")
                );
            return GCHandle.ToIntPtr(GCHandle.Alloc(del));
        }
        catch
        {
            return 0;
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "map_sum_with_delegate")]
    public static int MapSumWithDelegate(
        int n, 
        IntPtr del
        )
    {
        var actualDelegate = (MapOne) GCHandle.FromIntPtr(del).Target;
        return MapSum(n, actualDelegate);
    }

}
