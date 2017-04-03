#include "stdio.h"
#include "stdlib.h"
#include "math.h"

int main(int argc, char* argv[])
{
    int N = atoi(argv[1]), M = atoi(argv[2]), K, i;
    //printf("N = ");
    //scanf("%d", &N);
    //printf("\nM = ");
    //scanf("%d", &M);
    for (i = 1; i <= N; i++)
    {
        K = rand();
    }

    K = K % M + 1;
    //K = (abs(sin(N)*10000)) % M + 1;
    printf("Result: %d\n", K);
    return 0;
}

