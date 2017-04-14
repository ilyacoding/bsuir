#define _BSD_SOURCE
#include <stdio.h>
#include <sys/types.h>
#include <signal.h>
#include <stdio.h>
#include <unistd.h>
#include <dirent.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <libgen.h>
#include <sys/wait.h>

//                pid = fork();
//
//                if (errno != 0)
//                {
//                    fprintf(stderr, "%s: %s %s\n", prog, currentPath, strerror(errno));
//                    return -1;
//                }
//
//                if (pid == -1)
//                {
//                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
//                    return -1;
//                }
//                else if (pid == 0)
//                {
//                    ProcessFile(prog, currentPath);
//                    exit(3);
//                }

int main(int argc, char *argv[])
{
    char* prog = basename(argv[0]);
    int pid;

    int pid1 = fork();

    if (pid1 == -1)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }
    else if (pid1 == 0)
    {
        int pid2 = fork();
        if (pid2 == -1)
        {
            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
            return -1;
        }
        else if (pid2 == 0)
        {
            int pid3 = fork();
            if (pid3 == -1)
            {
                fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                return -1;
            }
            else if (pid3 == 0)
            {
                int pid4 = fork();
                if (pid4 == -1)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }
                else if (pid4 == 0)
                {
                    int pid8 = fork();
                    if (pid8 == -1)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }
                    else if (pid8 == 0)
                    {
                        // Process 8

                        // Process 8
                        exit(0);
                    }
                    // Process 4

                    // Process 4
                    exit(0);
                }

                int pid5 = fork();
                if (pid5 == -1)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }
                else if (pid5 == 0)
                {
                    // Process 5

                    // Process 5
                    exit(0);
                }

                int pid6 = fork();
                if (pid6 == -1)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }
                else if (pid6 == 0)
                {
                    int pid7 = fork();
                    if (pid7 == -1)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }
                    else if (pid7 == 0)
                    {
                        // Process 7

                        // Process 7
                        exit(0);
                    }
                    // Process 6

                    // Process 6
                    exit(0);
                }
                // Process 3

                // Process 3
                exit(0);
            }
            // Process 2
//            setpgid(pid3, 1234);
            fprintf(stdout, "process 3 pgroup: %d\n", getpgid(pid3));
            // Process 2
            exit(0);
        }
        // Process 1
        fprintf(stdout, "process 2 pgroup: %d\n", getpgid(pid2));
        // Process 1

        exit(1);
    }
    // Process 0
//    setpgid(pid1, pid1);
//    fprintf(stdout, "process 1 pgroup: %d\n", getpgid(pid1));
//    fprintf(stdout, "process 1 pgroup: %d\n", getpgid(pid1));
//    fprintf(stdout, "process 1 pgroup: %d\n", getpgid(pid1));
//    fprintf(stdout, "process 1 pgroup: %d\n", getpgid(pid1));
//    fprintf(stdout, "process 1 pgroup: %d\n", getpgid(pid1));
    waitpid(pid, 0, 0);
    // Process 0
    return 0;
}