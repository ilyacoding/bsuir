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
#include <sys/time.h>
#include <sys/stat.h>

char* TMP_CREATE_PS = "tmp_create_ps";
char* TMP_PID_LIST = "tmp_pid_list";

int sig1_received = 0;
int sig2_received = 0;

int send_to_pid;

long long curr_time() {
    struct timeval tv;
    gettimeofday(&tv, NULL);
    return tv.tv_usec;
}

void send_to(int n, int signo, int silent)
{
    if (silent == 0)
    {
        if (signo == SIGUSR1)
            fprintf(stdout, "%d %d %d послал SIGUSR1 to %d %lld\n", n, getpid(), getppid(), send_to_pid, curr_time());
        else
            fprintf(stdout, "%d %d %d послал SIGUSR2 to %d %lld\n", n, getpid(), getppid(), send_to_pid, curr_time());
    }
    errno = 0;
    kill(-send_to_pid, signo);
    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", "myprog", strerror(errno));
        return;
    }
    return;
}

void print_result(int ps_num)
{
    printf("%d) %d %d завершил работу после %d-го сигнала SIGUSR1 и %d-го сигнала SIGUSR2 %lld\n", ps_num, getpid(), getppid(), sig1_received, sig2_received, curr_time());
}

void *ps1_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("1 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
        if (sig2_received == 101)
        {
            print_result(1);
//            FILE* pid_list = fopen(TMP_PID_LIST, "r");
//            char str [100];
//            while(!feof (pid_list)) {
//                if (fgets(str, 100, pid_list))
//                {
//                    kill(atoi(str), SIGTERM);
//                    waitpid(atoi(str), NULL, 0);
//                }
//            }
//            fclose(pid_list);
            send_to(1, SIGTERM, 1);
            exit(0);
        }
        else
        {
            send_to(1, SIGUSR2, 0);
        }
    }
    else if (signo == SIGTERM)
    {
        print_result(1);
        exit(0);
    }
}

void *ps2_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("2 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
    }
    else if (signo == SIGTERM)
    {
        print_result(2);
        exit(0);
    }
}

void *ps3_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("3 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
    }
    else if (signo == SIGTERM)
    {
        print_result(3);
        exit(0);
    }
}

void *ps4_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("4 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
    }
    else if (signo == SIGTERM)
    {
        print_result(4);
        exit(0);
    }
}

void *ps5_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("5 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
    }
    else if (signo == SIGTERM)
    {
        print_result(5);
        exit(0);
    }
}

void *ps6_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("6 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
        send_to(6, SIGUSR1, 0);
    }
    else if (signo == SIGTERM)
    {
        send_to(6, SIGTERM, 1);
        print_result(6);
        exit(0);
    }
}

void *ps7_sig_handler(int signo)
{
    if (signo == SIGUSR1)
    {
        printf("7 %d %d получил SIGUSR1 %lld\n", getpid(), getppid(), curr_time());
        sig1_received++;
    }
    else if (signo == SIGTERM)
    {
        print_result(7);
        exit(0);
    }
}

void *ps8_sig_handler(int signo)
{
    if (signo == SIGUSR1)
    {
        printf("8 %d %d получил SIGUSR1 %lld\n", getpid(), getppid(), curr_time());
        sig1_received++;
        send_to(8, SIGUSR2, 0);
    }
    else if (signo == SIGTERM)
    {
        print_result(8);
        exit(0);
    }
}

int file_exist (char *filename)
{
    struct stat   buffer;
    return (stat (filename, &buffer) == 0);
}

int amount_of_lines(char* filename)
{
    FILE* fp = fopen(filename, "r");
    int ch;
    int lines = 0;
    while(!feof(fp))
    {
        ch = fgetc(fp);
        if(ch == '\n')
        {
            lines++;
        }
    }
    fclose(fp);
    return lines;
}

int main(int argc, char *argv[])
{
    char* prog = basename(argv[0]);
//    if(file_exist(TMP_CREATE_PS)) {
//        remove(TMP_CREATE_PS);
//    }
    if(file_exist(TMP_PID_LIST)) {
        remove(TMP_PID_LIST);
    }
//    FILE* startFile = fopen("tmp_create_ps", "w");
    FILE* pidFile = fopen(TMP_PID_LIST, "w");
    int pid1 = fork();

    if (pid1 == -1)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }
    else if (pid1 == 0)
    {
        int group_1 = getpid();
        int pid2 = fork();
        if (pid2 == -1)
        {
            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
            return -1;
        }
        else if (pid2 == 0)
        {
            int group_2 = getpid();
            int pid3 = fork();
            if (pid3 == -1)
            {
                fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                return -1;
            }
            else if (pid3 == 0)
            {
                setpgid(pid3, pid3);
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
                        signal(SIGUSR1, (void *)ps8_sig_handler);
                        signal(SIGTERM, (void *)ps8_sig_handler);
                        send_to_pid = group_1;

                        printf("8) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//                        fseek(startFile, 0L, SEEK_END);
//                        fputc('8', startFile);
//                        fclose(startFile);

                        fseek(pidFile, 0L, SEEK_END);
                        fprintf(pidFile, "%d\n", getpid());
                        fclose(pidFile);

                        while(1) { pause(); }
                        // Process 8
                    }
                    // Process 4
                    setpgid(pid4, group_2);
                    signal(SIGUSR2, (void *)ps4_sig_handler);
                    signal(SIGTERM, (void *)ps4_sig_handler);

                    printf("4) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//                    fseek(startFile, 0L, SEEK_END);
//                    fputc('4', startFile);
//                    fclose(startFile);

                    fseek(pidFile, 0L, SEEK_END);
                    fprintf(pidFile, "%d\n", getpid());
                    fclose(pidFile);

                    while(1) { pause(); }
                    // Process 4
                }
                int group_3 = getpid();
//                printf("PID3 = %d\n", group_3);

                int pid5 = fork();
                if (pid5 == -1)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }
                else if (pid5 == 0)
                {
                    // Process 5
                    setpgid(pid5, group_2);
                    signal(SIGUSR2, (void *)ps5_sig_handler);
                    signal(SIGTERM, (void *)ps5_sig_handler);

                    printf("5) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//                    fseek(startFile, 0L, SEEK_END);
//                    fputc('5', startFile);
//                    fclose(startFile);

                    fseek(pidFile, 0L, SEEK_END);
                    fprintf(pidFile, "%d\n", getpid());
                    fclose(pidFile);

                    while(1) { pause(); }
                    // Process 5
                }

                int pid6 = fork();
                if (pid6 == -1)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }
                else if (pid6 == 0)
                {
//                    setpgid(pid6, group_2);
                    int pid7 = fork();
                    if (pid7 == -1)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }
                    else if (pid7 == 0)
                    {
                        // Process 7
                        signal(SIGUSR1, (void *)ps7_sig_handler);
                        signal(SIGTERM, (void *)ps7_sig_handler);

                        printf("7) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//                        fseek(startFile, 0L, SEEK_END);
//                        fputc('7', startFile);
//                        fclose(startFile);

                        fseek(pidFile, 0L, SEEK_END);
                        fprintf(pidFile, "%d\n", getpid());
                        fclose(pidFile);

                        while(1) { pause(); }
                        // Process 7
                    }
                    // Process 6
                    setpgid(pid6, group_2);
                    send_to_pid = group_3;
                    signal(SIGUSR2, (void *)ps6_sig_handler);
                    signal(SIGTERM, (void *)ps6_sig_handler);

                    printf("6) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//                    fseek(startFile, 0L, SEEK_END);
//                    fputc('6', startFile);
//                    fclose(startFile);

                    fseek(pidFile, 0L, SEEK_END);
                    fprintf(pidFile, "%d\n", getpid());
                    fclose(pidFile);

                    while(1) { pause(); }
                    // Process 6
                }
                // Process 3
                setpgid(pid3, group_2);
                signal(SIGUSR2, (void *)ps3_sig_handler);
                signal(SIGTERM, (void *)ps3_sig_handler);

                printf("3) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//                fseek(startFile, 0L, SEEK_END);
//                fputc('3', startFile);
//                fclose(startFile);

                fseek(pidFile, 0L, SEEK_END);
                fprintf(pidFile, "%d\n", getpid());
                fclose(pidFile);

                while(1) { pause(); }
                // Process 3
            }
            // Process 2
            setpgid(0, group_2);
            signal(SIGUSR2, (void *)ps2_sig_handler);
            signal(SIGTERM, (void *)ps2_sig_handler);

            printf("2) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

//            fseek(startFile, 0L, SEEK_END);
//            fputc('2', startFile);
//            fclose(startFile);

            fseek(pidFile, 0L, SEEK_END);
            fprintf(pidFile, "%d\n", getpid());
            fclose(pidFile);

            while(1) { pause(); }
            // Process 2
        }
        // Process 1
        long size;
        setpgid(pid1, pid1);
        send_to_pid = pid2;

        signal(SIGUSR2, (void *)ps1_sig_handler);

//        fseek(startFile, 0L, SEEK_END);
//        fputc('1', startFile);

        printf("1) %d %d : %d process created\n", getpid(), getppid(), getpgrp());

        while(1)
        {
            if (amount_of_lines(TMP_PID_LIST) == 7)
                break;
        }

        fprintf(stdout, "All processes created.\n");
//        fclose(startFile);
//        remove("tmp_create_ps");

        send_to(1, SIGUSR2, 0);

        while(1) pause();
//         Process 1
    }

    waitpid(pid1, 0, 0);
//    fclose(startFile);
    fclose(pidFile);
//    remove("tmp_create_ps");
    remove(TMP_PID_LIST);
    // Process 0
    return 0;
}