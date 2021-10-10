#include <sys/types.h>
#include<sys/wait.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

int main(int argc, char *argv[] )
{
    pid_t pid[2];
    int i;
    int status;

    for (i=0; i<2; i++)
    {
        if ((pid[i] = fork()) == 0)
        {
            if (i == 0)
            {
                sleep(1);
                exit(1);
            }
            else if (i == 1)
            {
                sleep(5);
                exit(5);
            }    
        }
    }

    for (i=0; i<2; i++)
    {
        pid_t cpid = waitpid(pid[i], &status, 0);

        printf("Child %d terminated with status: %d\n", cpid, WEXITSTATUS(status));
    }
}