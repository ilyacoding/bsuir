#include <stdio.h>
#include <unistd.h>
#include <dirent.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <libgen.h>
#include <sys/wait.h>
#include <pthread.h>
#include <math.h>

struct calc_struct {
    double x;
    int m;
};

char* prog;

const double pi = 3.14159265358979323846;

int N;
int n;

char* tmp_filename_result = "result";
FILE* tmp_file_result;

int wait_file;
char* tmp_filename = "tmp";
FILE* tmp_file;

void wait_close()
{
    while (wait_file == 1);
    if (wait_file == 0)
    {
        wait_file = 1;
    }
    else
    {
        wait_close();
    }
}

void wait_open()
{
    wait_file = 0;
}

double fact(double num)
{
    double result = 1;
    for (double i = 1; i <= num; i++)
    {
        result *= i;
    }
    return result;
}

double x(int i)
{
    return (double) 2 * pi / N * i;
}

void* calc_element(void* strPar)
{
    struct calc_struct *str = (struct calc_struct*) strPar;
    double result = pow(str->x, 2 * (str->m) + 1) * pow(-1, str->m) / fact(2 * (str->m) + 1);

    wait_close();

    fprintf(tmp_file, "%ld %.20f\n", pthread_self(), result);
    fprintf(stdout, "%ld %.20f\n", pthread_self(), result);
//    fprintf(stdout, "m=%d x=%.20f pow1=%.20f pow2=%.2f fact=%.20f res=%.20f\n", str->m, str->x, pow(str->x, 2 * (str->m) + 1), pow(-1, str->m), (double)fact(2 * (str->m) + 1), result);

    free(str);
    wait_open();
}

double get_sum(int i)
{
    double sum = 0;
    int max_str = 255;
    char *buf = (char *)malloc(sizeof(char) * max_str);
    char* buf_ptr;
    FILE* fp = fopen(tmp_filename, "r");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    while (fgets(buf, max_str, fp) != NULL)  {
        buf_ptr = buf;
        while (buf_ptr[0] != ' ') buf_ptr++;
        buf_ptr++;
        sum += strtod(buf_ptr, NULL);
    }

    fprintf(tmp_file_result, "y[%d] = %.20f\n", i, sum);
//    fprintf(tmp_file_result, "y[%d] CHECK = %.20f\n", i, sin(x(i)));

    free(buf);
    fclose(fp);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return 0;
}

int main(int argc, char *argv[])
{
    struct calc_struct *str;
    pthread_t** pthread_array;
    int k;

    prog = basename(argv[0]);


    if (argc < 3)
    {
        fprintf(stderr, "%s: %s\n", prog, "Too few arguments. \nRight syntax: N n");
        return -1;
    }

    N = atoi(argv[1]);
    n = atoi(argv[2]);

    if (N < 1)
    {
        fprintf(stderr, "%s: %s\n", prog, "N >= 1");
        return -1;
    }

    if (n < 1)
    {
        fprintf(stderr, "%s: %s\n", prog, "n >= 1");
        return -1;
    }

    tmp_file_result = fopen(tmp_filename_result, "w");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    for (int i = 0; i < N; i++)
    {
        tmp_file = fopen(tmp_filename, "w");

        if (errno != 0)
        {
            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
            return -1;
        }

        pthread_array = (pthread_t**)malloc(sizeof(pthread_t*) * n);
        for (int k = 0; k < n; k++)
        {
            pthread_array[k] = (pthread_t*)malloc(sizeof(pthread_t));
        }

        k = 0;

        for (int j = 0; j < n; j++)
        {
            str = (struct calc_struct*)malloc(sizeof(struct calc_struct));
            str->x = x(i);
            str->m = j;
            if((errno = pthread_create(pthread_array[k++], NULL, calc_element, str)) != 0) {
                fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                return 1;
            }
        }

        for (int l = 0; l < n; l++)
        {
            if ((errno = pthread_join(*(pthread_array[l]), NULL)) != 0)
            {
                fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                return -1;
            }
        }

        printf("NEXT\n\n");

        fclose(tmp_file);

        if (errno != 0)
        {
            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
            return -1;
        }

        get_sum(i);
        free(pthread_array);
    }

    fclose(tmp_file_result);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    remove(tmp_filename);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return 0;
}