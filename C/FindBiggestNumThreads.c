#include<stdio.h>
#include<pthread.h>
#include<unistd.h>
#include<stdlib.h>
#include<string.h>

pthread_mutex_t mtx;
int MAX = -100000;
int * list;
int threadName = -1;

struct args {
    int start;
    int end;
    int nameID;
};

void *findMax(void *input) {
    int s = ((struct args*)input)->start;
    int e = ((struct args*)input)->end;
    int name = ((struct args*)input)->nameID;

    int * lPointer = list;
    lPointer += s;
    int lMax = -10000;
    for (int j = s; j <= e;j++) {
        if (*lPointer > lMax)
            lMax = *lPointer;
        
        lPointer++;
    }

    pthread_mutex_lock(&mtx);
    if (lMax > MAX) {
        MAX = lMax;
        threadName = name;
    }
    pthread_mutex_unlock(&mtx);
    pthread_exit(0);
}

int main() {
    FILE *fp;
    char buff[255];
    int entries;

    if (access("list.txt", F_OK) == 0) {
        fp = fopen("list.txt", "r");

        fscanf(fp, "%s\n", buff);
        entries = atoi(buff);
        
        int list1[entries];
        memset(buff, 0, sizeof buff);

        int i = 0;
        while (1) {
            fscanf(fp, "%s\n", buff);
            if (strlen(buff) <= 0) break;
            list1[i] = atoi(buff);
            memset(buff, 0, sizeof buff);
            i++;
        }

        list = list1;

        int numOfTh = entries / 1000;
        pthread_t thread_id[numOfTh];
        int thread_args[numOfTh];

        for (i = 0; i <= numOfTh; i++) {
            struct args *thread = (struct args *)malloc(sizeof(struct args));
            thread->start= i*1000;
            if ((i+1)*1000 > entries) {
                thread->end=entries - 1;
            } else {
                thread->end=(i+1)*1000 - 1;
            }

            thread->nameID=i;

            pthread_create(&thread_id[i], NULL, *findMax, (void *)thread);
        }

        for (int i = 0; i <= numOfTh; i++)
            pthread_join(thread_id[i], NULL);
    }
    printf("Found \"%d\" with thread \"%d\"", MAX, threadName);
    return 0;
}