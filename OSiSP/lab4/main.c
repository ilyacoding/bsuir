#include <stdio.h>
#include <sys/types.h>
#include <signal.h>
#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <libgen.h>
#include <sys/wait.h>
#include <sys/time.h>
#include <sys/stat.h>

char* prog;
char* TMP_PID_LIST = "tmp_pid_list";
char* TMP_SIG = "tmp_sig";
int pid_list[10];

int sig1_received = 0;
int sig2_received = 0;
int send_to_pid;

int wait_sig(long num)
{
    FILE* fp = fopen(TMP_SIG, "r");

    if (errno != 0)
    {
        fprintf(stderr, "123%s: %s\n", prog, strerror(errno));
        return -1;
    }
    long size = 0;
    while (size < num) {
        fseek(fp, 0L, SEEK_END);

        if (errno != 0) {
            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
            return -1;
        }

        size = ftell(fp);

        if (errno != 0)
        {
            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
            return -1;
        }
    }

    fclose(fp);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return 0;
}

void add_sig()
{
    FILE* fp = fopen(TMP_SIG, "a");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return;
    }

    fprintf(fp, "1");

    fclose(fp);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return;
    }
}

void clear_sig()
{
    FILE* fp = fopen(TMP_SIG, "w");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return;
    }

    fclose(fp);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return;
    }
}

int get_pid_list()
{
    FILE* fp = fopen(TMP_PID_LIST, "r");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    char buf[10];
    int lines = 2;
    while(!feof(fp))
    {
        fgets(buf, 10, fp);
        pid_list[lines++] = atoi(buf);
    }

    fclose(fp);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return lines;
}

long long curr_time() {
    struct timeval tv;
    struct timezone tz;

    errno = 0;

    gettimeofday(&tv, &tz);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return tv.tv_usec;
}

void send_to(int n, int signo, int silent)
{
    if (silent == 0)
    {
        if (signo == SIGUSR1)
            fprintf(stdout, "%d %d %d послал SIGUSR1 %lld\n", n, getpid(), getppid(), curr_time());
        else
            fprintf(stdout, "%d %d %d послал SIGUSR2 %lld\n", n, getpid(), getppid(), curr_time());
    }

    errno = 0;

    kill(-send_to_pid, signo);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %d\n", prog, strerror(errno), send_to_pid);
        return;
    }

    return;
}

void send_to_directly(int n, int signo, int silent)
{
    if (silent == 0)
    {
        if (signo == SIGUSR1)
            fprintf(stdout, "%d %d %d послал SIGUSR1 %lld\n", n, getpid(), getppid(), curr_time());
        else
            fprintf(stdout, "%d %d %d послал SIGUSR2 %lld\n", n, getpid(), getppid(), curr_time());
    }

    errno = 0;

    kill(send_to_pid, signo);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s %d\n", prog, strerror(errno), send_to_pid);
        return;
    }

    return;
}

void print_result(int ps_num)
{
    printf("%d %d завершил работу после %d-го сигнала SIGUSR1 и %d-го сигнала SIGUSR2 %lld\n", getpid(), getppid(), sig1_received, sig2_received, curr_time());
//    printf("%d) %d %d завершил работу после %d-го сигнала SIGUSR1 и %d-го сигнала SIGUSR2 %lld\n", ps_num, getpid(), getppid(), sig1_received, sig2_received, curr_time());
}

void *ps1_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("1 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;

        if (sig2_received == 101)
        {
            get_pid_list();
            send_to_pid = pid_list[2];
            send_to_directly(1, SIGTERM, 1);
            waitpid(send_to_pid, 0, 0);

            print_result(1);
            exit(0);
        }
        else
        {
            clear_sig();
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
        add_sig();
    }
    else if (signo == SIGTERM)
    {
        print_result(2);
        get_pid_list();
        send_to_pid = pid_list[3];
        send_to_directly(2, SIGTERM, 1);
        waitpid(send_to_pid, 0, 0);

        exit(0);
    }
}

void *ps3_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("3 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
        add_sig();
    }
    else if (signo == SIGTERM)
    {
        print_result(3);
        get_pid_list();

        send_to_pid = pid_list[4];
        send_to_directly(1, SIGTERM, 1);
        waitpid(send_to_pid, 0, 0);

        send_to_pid = pid_list[5];
        send_to_directly(1, SIGTERM, 1);
        waitpid(send_to_pid, 0, 0);

        send_to_pid = pid_list[6];
        send_to_directly(1, SIGTERM, 1);
        waitpid(send_to_pid, 0, 0);

        exit(0);
    }
}

void *ps4_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("4 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
        add_sig();
    }
    else if (signo == SIGTERM)
    {
        print_result(4);
        get_pid_list();

        send_to_pid = pid_list[8];
        send_to_directly(1, SIGTERM, 1);
        waitpid(send_to_pid, 0, 0);

        exit(0);
    }
}

void *ps5_sig_handler(int signo)
{
    if (signo == SIGUSR2)
    {
        printf("5 %d %d получил SIGUSR2 %lld\n", getpid(), getppid(), curr_time());
        sig2_received++;
        add_sig();
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

        wait_sig(4);
        clear_sig();

        send_to(6, SIGUSR1, 0);
    }
    else if (signo == SIGTERM)
    {
        print_result(6);
        get_pid_list();

        send_to_pid = pid_list[7];
        send_to_directly(1, SIGTERM, 1);
        waitpid(send_to_pid, 0, 0);

        exit(0);
    }
}

void *ps7_sig_handler(int signo)
{
    if (signo == SIGUSR1)
    {
        printf("7 %d %d получил SIGUSR1 %lld\n", getpid(), getppid(), curr_time());
        sig1_received++;
        add_sig();
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
        sig1_received++;
        printf("8 %d %d получил SIGUSR1 %lld\n", getpid(), getppid(), curr_time());

        wait_sig(1);
        clear_sig();
        send_to(8, SIGUSR2, 0);
    }
    else if (signo == SIGTERM)
    {
        print_result(8);
        exit(0);
    }
}

int amount_of_lines(char* filename)
{
    FILE* fp = fopen(filename, "r");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

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

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    return lines;
}

int main(int argc, char *argv[])
{
    prog = basename(argv[0]);

    FILE* pidFile = fopen(TMP_PID_LIST, "w");

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

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
                        send_to_pid = group_1;
                        signal(SIGUSR1, (void *)ps8_sig_handler);
                        signal(SIGTERM, (void *)ps8_sig_handler);

                        while(amount_of_lines(TMP_PID_LIST) != 6);

                        fseek(pidFile, 0L, SEEK_END);

                        if (errno != 0)
                        {
                            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                            return -1;
                        }

                        fprintf(pidFile, "%d\n", getpid());

                        fclose(pidFile);

                        if (errno != 0)
                        {
                            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                            return -1;
                        }

                        while(1) pause();
                        // Process 8
                    }
                    // Process 4
                    setpgid(pid4, group_2);
                    signal(SIGUSR2, (void *)ps4_sig_handler);
                    signal(SIGTERM, (void *)ps4_sig_handler);

                    while(amount_of_lines(TMP_PID_LIST) != 2);

                    fseek(pidFile, 0L, SEEK_END);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }

                    fprintf(pidFile, "%d\n", getpid());

                    fclose(pidFile);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }

                    while(1) pause();
                    // Process 4
                }
                int group_3 = getpid();

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

                    while(amount_of_lines(TMP_PID_LIST) != 3);

                    fseek(pidFile, 0L, SEEK_END);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }

                    fprintf(pidFile, "%d\n", getpid());

                    fclose(pidFile);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }

                    while(1) pause();
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

                        while(amount_of_lines(TMP_PID_LIST) != 5);

                        fseek(pidFile, 0L, SEEK_END);

                        if (errno != 0)
                        {
                            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                            return -1;
                        }

                        fprintf(pidFile, "%d\n", getpid());

                        fclose(pidFile);

                        if (errno != 0)
                        {
                            fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                            return -1;
                        }

                        while(1) pause();
                        // Process 7
                    }
                    // Process 6
                    setpgid(pid6, group_2);
                    send_to_pid = group_3;
                    signal(SIGUSR2, (void *)ps6_sig_handler);
                    signal(SIGTERM, (void *)ps6_sig_handler);

                    while(amount_of_lines(TMP_PID_LIST) != 4);

                    fseek(pidFile, 0L, SEEK_END);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }

                    fprintf(pidFile, "%d\n", getpid());

                    fclose(pidFile);

                    if (errno != 0)
                    {
                        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                        return -1;
                    }

                    while(1) pause();
                    // Process 6
                }
                // Process 3
                setpgid(pid3, group_2);
                signal(SIGUSR2, (void *)ps3_sig_handler);
                signal(SIGTERM, (void *)ps3_sig_handler);

                while(amount_of_lines(TMP_PID_LIST) != 1);

                fseek(pidFile, 0L, SEEK_END);

                if (errno != 0)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }

                fprintf(pidFile, "%d\n", getpid());

                fclose(pidFile);

                if (errno != 0)
                {
                    fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                    return -1;
                }

                while(1) pause();
                // Process 3
            }
            // Process 2
            setpgid(0, group_2);
            signal(SIGUSR2, (void *)ps2_sig_handler);
            signal(SIGTERM, (void *)ps2_sig_handler);

            fseek(pidFile, 0L, SEEK_END);

            if (errno != 0)
            {
                fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                return -1;
            }

            fprintf(pidFile, "%d\n", getpid());

            fclose(pidFile);

            if (errno != 0)
            {
                fprintf(stderr, "%s: %s\n", prog, strerror(errno));
                return -1;
            }

            while(1) pause();
            // Process 2
        }
        // Process 1
        setpgid(pid1, pid1);
        send_to_pid = pid2;

        signal(SIGUSR2, (void *)ps1_sig_handler);

        while(1)
        {
            if (amount_of_lines(TMP_PID_LIST) == 7)
                break;
        }

        sleep(10);

        send_to(1, SIGUSR2, 0);

        while(1) pause();
//         Process 1
    }

    waitpid(pid1, 0, 0);
    fclose(pidFile);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    remove(TMP_PID_LIST);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    remove(TMP_SIG);

    if (errno != 0)
    {
        fprintf(stderr, "%s: %s\n", prog, strerror(errno));
        return -1;
    }

    // Process 0
    return 0;
}