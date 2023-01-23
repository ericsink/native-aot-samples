
#include <cstdint>
#include <stdio.h>

extern "C" int32_t multiply(int32_t, int32_t);

int main()
{
    int32_t c = multiply(7, 6);
    printf("%d\n", c);
    return 0;
}

