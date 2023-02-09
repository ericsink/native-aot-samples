
#include <cstdint>
#include <stdio.h>

extern "C" uintptr_t get_hello_string();
extern "C" int32_t get_string_length(uintptr_t);
extern "C" uintptr_t banish_letter_l(uintptr_t);
extern "C" void free_object_handle(uintptr_t);

int main()
{
    // the original string is "Hello World"
    uintptr_t s1 = get_hello_string();

    // the length of the original string is 11
    int32_t len1 = get_string_length(s1);
    printf("%d\n", len1);

    // the new string should be "HeNOTNOTo WorNOTd"
    uintptr_t s2 = banish_letter_l(s1);

    // the length of the new string is now 17
    int32_t len2 = get_string_length(s2);
    printf("%d\n", len2);

    // need to release both string objects
    free_object_handle(s1);
    free_object_handle(s2);

    return 0;
}

