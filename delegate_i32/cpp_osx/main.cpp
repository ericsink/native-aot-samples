
#include <cstdint>
#include <stdio.h>

typedef int (*MapOne)(int);

extern "C" int      map_sum_with_funcptr(int n, MapOne f);
extern "C" intptr_t create_delegate(MapOne f);
extern "C" int      map_sum_with_delegate(int n, intptr_t del);

int divisible_by_42(int x)
{
    return (x % 42) == 0;
}

int main()
{
    {
        int32_t total = map_sum_with_funcptr(
            1000, 
            divisible_by_42
            );
        printf("%d\n", total);
    }

    {
        intptr_t del = create_delegate(
            divisible_by_42
            );
        int32_t total = map_sum_with_delegate(
            1000, 
            del
            );
        printf("%d\n", total);
    }

    return 0;
}

