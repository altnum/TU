#include <sys/types.h>
#include<sys/wait.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <semaphore.h>
#include <threads.h>

sem_t semaphore;

int main(int argc, char *argv[] )
{
    pid_t pid[2];
    int i;
    int status;
    sem_init(&semaphore, 2, 1);

    for (i=0; i<2; i++)
    {
        if ((pid[i] = fork()) == 0)
        {
            if (i == 0)
            {
                int j;
                for (j=1; j<=9; j+=2)
                {   
                    sem_wait(&semaphore);
                    printf("Son 1:%d\n", j);
                    sleep(1);
                    sem_post(&semaphore);
                }

                exit(1);
            }
            else if (i == 1)
            {
                int z;
                for (z=2; z<=10; z+=2)
                {
                    sem_wait(&semaphore);
                    printf("Son 2:%d\n", z);
                    sleep(1);
                    sem_post(&semaphore);
                }

                exit(5);
            }   
        }
    }
    
    sem_destroy(&semaphore);

    for (i=0; i<2; i++)
    {
        pid_t cpid = waitpid(pid[i], &status, 0);
    }
}