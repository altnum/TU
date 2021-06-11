#include <sys/types.h>
#include<sys/wait.h>
#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <errno.h>

int main(int argc, char *argv[]) {
    pid_t childPid;
    int i;
    int status;
    char *com1 = argv[1];
    char *com2 = argv[2];


    for (i=0; i<2; i++){
        
        if ((childPid = fork()) == 0) {
            if (i == 0) {
                char * argv_list[] = {com1, NULL};
                sleep(3);

                if (execvp(com1,argv_list) < 0) {
                    perror("First command execution failed.");
                    exit(EXIT_FAILURE);
                }
                exit(0);
            } else if (i == 1) {
                char * argv_list[] = {com2, NULL};

                sleep(1);

                if (execvp(com2,argv_list) < 0) {
                    perror("Second command execution failed.");
                    exit(EXIT_FAILURE);
                }

                exit(0);
            } 
        }
        printf("[%s] %d\n", argv[i+1], childPid);
    }

    int failed;
    failed = 0;
    
    pid_t cpid;

    cpid = wait(&status);
    if (WEXITSTATUS(status) != 0) {
        failed += 1;
    }

    wait(&status);
    if (WEXITSTATUS(status) != 0) {
        failed += 1;
    }

    printf("ID of the first successful command: %d.\n", cpid);
    
    if (failed == 2)
        printf("-1");

    return 0;
}