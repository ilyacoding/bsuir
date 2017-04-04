#define _BSD_SOURCE

#include <stdio.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dirent.h>
#include <stddef.h>
#include <stdlib.h>
#include <unistd.h>
#include <time.h>
#include <string.h>
#include <errno.h>
#include <libgen.h>

int ProcessDir(char* prog, char* directory, int from, int to, FILE* fd_output, unsigned long* counter)
{
	errno = 0;
	DIR *dp = opendir(directory);
	struct dirent *d;

	if (dp == NULL && errno != 0)
	{
		fprintf(stderr, "%s: %s %s\n", prog, directory, strerror(errno));
		return -1;
	}

	errno = 0;
	while ((d = readdir(dp)) != NULL)
	{
		struct stat file_stat;
		char *currentPath = (char *)malloc(strlen(directory) + strlen(d->d_name) + 2);

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
				ProcessDir(prog, currentPath, from, to, fd_output, counter);
				break;
			case DT_REG:
				if (stat(currentPath, &file_stat) != 0)
				{	
					fprintf(stderr, "%s: %s %s\n", prog, currentPath, strerror(errno));
					return -1;
				}

				(*counter)++;
				if (file_stat.st_size > from && file_stat.st_size < to)
				{
					fprintf(fd_output, "%s %s %d\n", currentPath, d->d_name, (int)file_stat.st_size);
				}
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
	FILE* fd_output;
	DIR* dPtr;
	int from;
	int to;
	unsigned long* counter = (unsigned long*)malloc(sizeof(unsigned long));

	if (argc < 5)
	{
		fprintf(stderr, "%s: %s\n", prog, "Too few arguments. \nRight syntax: directory_to_check size_from size_to output_file");
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

	from = atoi(argv[2]);
	to = atoi(argv[3]);

	if (from > to)
	{
		fprintf(stderr, "%s: %s\n", prog, "'TO' must me <= 'FROM'.");
		return -1;
	}

	if (from < 0)
	{
		fprintf(stderr, "%s: %s\n", prog, "'FROM' must be >= 0.");
		return -1;		
	}

	if (errno != 0)
	{
		fprintf(stderr, "%s: %s\n", prog, strerror(errno));
		return -1;
	}

	fd_output = fopen(argv[4], "w");

	if (errno != 0)
	{
		fprintf(stderr, "%s: %s\n", prog, strerror(errno));
		return -1;
	}

	(*counter) = 0;
	ProcessDir(prog, directory, from, to, fd_output, counter);

	fclose(fd_output);

	if (errno != 0)
	{
		fprintf(stderr, "%s: %s\n", prog, strerror(errno));
		return -1;
	}

	printf("%lu\n", *counter);
	return 0;
}