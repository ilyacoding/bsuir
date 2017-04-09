#include <stdio.h>
#include <unistd.h>
#include <dirent.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <libgen.h>
#include <sys/wait.h>

int max_threads;
int curr_threads = 0;

int ProcessFile(char* prog, char* filepath)
{
    char* real_path = realpath(filepath, NULL);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %s\n", prog, real_path, strerror(errno));
        return -1;
    }

    FILE* file = fopen(real_path, "r");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %s\n", prog, real_path, strerror(errno));
        return -1;
    }

    int k = 0;
    int symbol;

    int** array = (int**)malloc(256*sizeof(int*));
    for (int i = 0; i < 256; i++)
    {
        array[i] = (int *) malloc(sizeof(int));
        (*array[i]) = 0;
    }

    while ((symbol = fgetc(file)) != EOF)
    {
        if (symbol >= 0)
        {
            (*array[symbol])++;
            k++;
        }
    }

    fclose(file);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %s\n", prog, real_path, strerror(errno));
        return -1;
    }

    double delta = 1.0/k;
    char* result = (char*)malloc(5000*sizeof(char));

    sprintf(result, "%d %s %d ", getpid(), real_path, k);

    for (unsigned char i = 0; i < 255; i++)
    {
        if ((*array[i]) > 0)
        {
            char* string = (char*)malloc(100*sizeof(char));
            sprintf(string, "%x %d; ", i, *array[i]);
            strcat(result, string);
            free(string);
        }
    }
    strcat(result, "\n");
    fprintf(stdout, "%s", result);
    for (int i = 0; i < 256; i++)
        free(array[i]);
    free(array);
    free(result);
    free(real_path);
    exit(3);
}

int ProcessDir(char* prog, char* directory)
{
    struct dirent *d;
    DIR *dp = opendir(directory);

    if (dp == NULL && errno != 0)
    {
        fprintf(stderr, "%s: %s %s\n", prog, directory, strerror(errno));
        return -1;
    }

    errno = 0;
    while ((d = readdir(dp)) != NULL)
    {
        char *currentPath = (char *)malloc(strlen(directory) + strlen(d->d_name) + 2);
        int pid;
        int status;

        strcpy(currentPath, directory);
        strcat(currentPath, d->d_name);

        if (strcmp(d->d_name, ".") == 0 || strcmp(d->d_name, "..") == 0)
        {
            free(currentPath);
            continue;
        }
        errno = 0;

        switch(d->d_type)
        {
            case DT_DIR:
                strcat(currentPath, "/");
                ProcessDir(prog, currentPath);
                break;
            case DT_REG:

                if (max_threads == 1)
                {
                    ProcessFile(prog, currentPath);
                    break;
                }

                while (curr_threads >= max_threads - 1)
                {
                    wait(&status);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s %s\n", prog, currentPath, strerror(errno));
                        return -1;
                    }

                    if (WIFEXITED(status) != 0)
                    {
                        curr_threads--;
                    }
                }

                pid = fork();

                if (errno != 0)
                {
                    fprintf(stderr, "%s: %s %s\n", prog, currentPath, strerror(errno));
                    return -1;
                }

                if (pid == -1)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }
                else if (pid == 0)
                {
                    ProcessFile(prog, currentPath);
                    exit(3);
                }

                curr_threads++;

                break;
            default:
                break;
        }
        free(currentPath);
    }

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %s\n", prog, directory, strerror(errno));
        return -1;
    }

    closedir(dp);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %s\n", prog, directory, strerror(errno));
        return -1;
    }

    return 0;
}

int main(int argc, char *argv[])
{
    char* prog = basename(argv[0]);
    char* directory;
    DIR* dPtr;

    if (argc < 3)
    {
        fprintf(stderr, "%s: %s\n", prog, "Too few arguments. \nRight syntax: directory_to_check number_of_processes");
        return -1;
    }

    directory = realpath(argv[1], NULL);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    if (strcmp(directory, "/") != 0)
    {
        strcat(directory, "/");
    }

    dPtr = opendir(directory);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    closedir(dPtr);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    max_threads = atoi(argv[2]);

    if (max_threads <= 0)
    {
        fprintf(stderr, "%s: Maximum number of threads must be >= 1\n", prog);
        return -1;
    }

    ProcessDir(prog, directory);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return 0;
}